using AutoMapper;
using KpiScheduleCore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using ScheduleService.BLL.Extentions;
using ScheduleService.BLL.Services.Abstractions;
using ScheduleService.CoreModels;
using ScheduleService.CoreModels.ContractModels;
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

        public async Task<List<LessonDto>> GetLessons(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var getLessonsFromKpiApi = await _kpiScheduleService.GetGroupLessonsList(user.GroupName);
            var dtoLessons = _mapper.Map<List<LessonDto>>(getLessonsFromKpiApi);
            var curWeekN = await _kpiScheduleService.GetCurrentWeekNumber();

            if (getLessonsFromKpiApi == null)
            {
                return null;
            }

            var lessonsWithDate = SetLessonsDate(dtoLessons, curWeekN);

            var lessonsToReturn = await AddLessonsToDb(lessonsWithDate);

            return lessonsToReturn;
        }

        private async Task<List<LessonDto>> AddLessonsToDb(List<LessonDto> getLessonsFromKpiApi)
        {
            var getLessonsFromDb = await _uow.LessonRepository.GetAll();

            foreach (var item in getLessonsFromKpiApi)
            {
                var lesson = _mapper.Map<Lesson>(item);
                var lessonId = lesson.lesson_id;

                if (!getLessonsFromDb.Any(x => x.lesson_id == lessonId))
                {
                    _uow.LessonRepository.Add(lesson);
                    await _uow.SaveChanges();

                    await AddTeachersToDbIfNotExsist(item.Teachers);

                    await AddTeacherToLesson(item);
                }
            }

            var lessons = await _uow.LessonRepository.GetByRangeAsync(getLessonsFromDb.Select(x => x.lesson_id));

            var lessonsToReturn = _mapper.Map<List<LessonDto>>(lessons);

            return lessonsToReturn;
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

                _uow.TeacherOnLessonRepository.Add(teacherOnLesson);
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

        private List<LessonDto> SetLessonsDate(List<LessonDto> lessons, int curWeekN)
        {
            var currDate = DateTime.Now;
            foreach (var item in lessons)
            {
                if (curWeekN == Convert.ToInt32(item.lesson_week))
                {
                    var lessonDate = currDate.AddDays(Convert.ToInt32(item.day_number) - (currDate.LocalizationDayOfWeek() + 1));
                    item.lesson_date = lessonDate;
                }
                else
                {
                    if (Convert.ToInt32(item.lesson_week) == 1)
                    {
                        var lessonDate = currDate.AddDays(Convert.ToInt32(item.day_number) - (currDate.LocalizationDayOfWeek() + 1) - 7);
                        item.lesson_date = lessonDate;
                    }
                    else
                    {
                        var lessonDate = currDate.AddDays(Convert.ToInt32(item.day_number) - (currDate.LocalizationDayOfWeek() + 1) + 7);
                        item.lesson_date = lessonDate;
                    }
                }
            }
            return lessons;
        }
    }
}
