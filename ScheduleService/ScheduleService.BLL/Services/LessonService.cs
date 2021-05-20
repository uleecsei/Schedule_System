using AutoMapper;
using KpiScheduleCore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScheduleService.BLL.Extentions;
using ScheduleService.BLL.Services.Abstractions;
using ScheduleService.CoreModels.ContractModels;
using ScheduleService.Models.ContractModels;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.Repository;
using SheduleService.Core.Repository.Interfaces;
using SheduleService.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IKpiScheduleService _kpiScheduleService;
        private readonly UserManager<User> _userManager;


        public LessonService(IUnitOfWork uow, IKpiScheduleService kpiScheduleService, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _uow = uow;
            _mapper = mapper;
            _kpiScheduleService = kpiScheduleService;
        }

        public async Task<bool> PostLessonInformation(int lessonId, DateTime date, LessonInforamtionDto informationDto)
        {
            LessonInHistory lessonInHistory = await GetOrCreateLessonInHistory(lessonId, date);

            var inforamtionToCreate = _mapper.Map<LessonInformation>(informationDto);
            inforamtionToCreate.LessonInHistoryId = lessonInHistory.LessonInHistoryId;

            _uow.LessonInformationRepository.Add(inforamtionToCreate);
            return await _uow.SaveChanges();
        }

        public async Task<bool> PostLessonFile(int lessonId, DateTime date, LessonFileDto lessonFile)
        {
            LessonInHistory lessonInHistory = await GetOrCreateLessonInHistory(lessonId, date);

            var fileToCreate = _mapper.Map<LessonFile>(lessonFile);
            fileToCreate.LessonInHistoryId = lessonInHistory.LessonInHistoryId;

            _uow.LessonFileRepository.Add(fileToCreate);
            return await _uow.SaveChanges();
        }

        private async Task<LessonInHistory> GetOrCreateLessonInHistory(int lessonId, DateTime date)
        {
            LessonInHistory lessonInHistory = await _uow.lessonInHistoryRepository.GetByLessonIdAndDate(lessonId, date);
            if (lessonInHistory == null)
            {
                lessonInHistory = new LessonInHistory()
                {
                    lesson_date = date,
                    lesson_id = lessonId
                };
                _uow.lessonInHistoryRepository.Add(lessonInHistory);
                await _uow.SaveChanges();
            }
            return lessonInHistory;
        }

        public async Task<LessonResponse> GetLessons(string userId)
        {
            var user = await _userManager.Users.Include(x => x.Group).FirstOrDefaultAsync(x => x.Id == userId);
            var getLessonsFromKpiApi = await _kpiScheduleService.GetGroupLessonsList(user.Group.GroupName);

            if (getLessonsFromKpiApi != null)
            {
                var curWeekN = await _kpiScheduleService.GetCurrentWeekNumber();
                var dtoLessons = _mapper.Map<List<LessonDto>>(getLessonsFromKpiApi);
                await AddGroupToDbIfNotExsist(user.Group.GroupName, getLessonsFromKpiApi.FirstOrDefault().group_id);
                await SaveCurentWeekNumber(curWeekN);
                await AddLessonsToDb(dtoLessons);
            }

            var group = await _uow.GroupRepository.GetByName(user.Group.GroupName);

            var lessonsFromDb = await _uow.LessonRepository.GetLessonsBuGroupId(group.group_id);
            var currentWeekNumber = await _uow.CurrentWeekNumberRepository.GetCurrentWeek();
            var lessonsToReturn = _mapper.Map<List<LessonDto>>(lessonsFromDb);
            return new LessonResponse()
            {
                Lessons = lessonsToReturn,
                CurrentWeekNumber = currentWeekNumber
            };
        }

        private async Task SaveCurentWeekNumber(int curWeekN)
        {
            await _uow.CurrentWeekNumberRepository.SetCurrentWeek(curWeekN);
            await _uow.SaveChanges();
        }

        private async Task AddGroupToDbIfNotExsist(string groupName, int group_id)
        {
            var tryGet = await _uow.GroupRepository.GetById(group_id);
            if (tryGet != null)
            {
                return;
            }

            var group = new Group()
            {
                group_id = group_id,
                GroupName = groupName
            };

            _uow.GroupRepository.Add(group);
            await _uow.SaveChanges();
        }

        private async Task AddLessonsToDb(List<LessonDto> getLessonsFromKpiApi)
        {
            //TO-Do 
            //await UpdateOldLessons(getLessonsFromKpiApi, lessonOfCurrentSchedule);
            await AddNewLessons(getLessonsFromKpiApi);
        }

        private async Task AddNewLessons(List<LessonDto> getLessonsFromKpiApi)
        {
            foreach (var item in getLessonsFromKpiApi)
            {
                var lesson = _mapper.Map<Lesson>(item);
                lesson.DateAdded = DateTime.Now;
                lesson.IsCurrentSchedule = true;

                _uow.LessonRepository.AddIfNotExsist(lesson, x=> x.lesson_id == lesson.lesson_id);
                await _uow.SaveChanges();
                await AddTeachersToDbIfNotExsist(item.Teachers);

                await AddTeacherToLesson(item);
            }
        }

        private async Task UpdateOldLessons(List<LessonDto> getLessonsFromKpiApi, IEnumerable<Lesson> lessonOfCurrentSchedule)
        {
            foreach (var item in lessonOfCurrentSchedule)
            {
                if (getLessonsFromKpiApi.Any(x => x.lesson_id == item.lesson_id))
                {
                    item.IsCurrentSchedule = false;
                    item.DateRemoved = DateTime.Now;
                }
            }
            await _uow.SaveChanges();
        }

        private async Task AddTeacherToLesson(LessonDto lesson)
        {
            foreach (var teacher in lesson.Teachers)
            {
                var teacherOnLesson = new TeacherOnLesson()
                {
                    Lesson_Id = lesson.lesson_id,
                    Teacher_Id = teacher.teacher_id
                };

                _uow.TeacherOnLessonRepository.AddIfNotExsist(teacherOnLesson, 
                    x => x.Lesson_Id == lesson.lesson_id && x.Teacher_Id == teacher.teacher_id);
            }
            await _uow.SaveChanges();
        }

        private async Task AddTeachersToDbIfNotExsist(ICollection<TeacherDto> teachers)
        {
            var getTeacherFromDb = await _uow.TeacherRepository.GetAll();

            foreach (var item in teachers)
            {
                var teacher = _mapper.Map<Teacher>(item);
                var teacherId = teacher.teacher_id;

                if (!getTeacherFromDb.Any(x => x.teacher_id == teacherId))
                {
                    _uow.TeacherRepository.Add(teacher);
                }
            }
            await _uow.SaveChanges();
        }



        //private List<LessonDto> SetLessonsDate(List<LessonDto> lessons, int curWeekN)
        //{
        //    var currDate = DateTime.Now;
        //    foreach (var item in lessons)
        //    {
        //        if (curWeekN == Convert.ToInt32(item.lesson_week))
        //        {
        //            var lessonDate = currDate.AddDays(Convert.ToInt32(item.day_number) - (currDate.LocalizationDayOfWeek() + 1));
        //            item.lesson_date = lessonDate;
        //        }
        //        else
        //        {
        //            if (Convert.ToInt32(item.lesson_week) == 1)
        //            {
        //                var lessonDate = currDate.AddDays(Convert.ToInt32(item.day_number) - (currDate.LocalizationDayOfWeek() + 1) - 7);
        //                item.lesson_date = lessonDate;
        //            }
        //            else
        //            {
        //                var lessonDate = currDate.AddDays(Convert.ToInt32(item.day_number) - (currDate.LocalizationDayOfWeek() + 1) + 7);
        //                item.lesson_date = lessonDate;
        //            }
        //        }
        //    }
        //    return lessons;
        //}
    }
}
