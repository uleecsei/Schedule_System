using KpiScheduleCore.Services.Interfaces;
using ScheduleService.BLL.Extentions;
using ScheduleService.BLL.Services.Abstractions;
using ScheduleService.Models;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services
{
    class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IKpiScheduleService _kpiScheduleService;

        public LessonService(ILessonRepository lessonRepository, IKpiScheduleService kpiScheduleService)
        {
            _lessonRepository = lessonRepository;
            _kpiScheduleService = kpiScheduleService;
        }

        public async Task<List<Lesson>> GetLessons(string groupName)
        {
            var getLessonsFromKpiApi = await _kpiScheduleService.GetGroupLessonsList(groupName);
            var getLessonsFromDb = await _lessonRepository.GetAll();

            var curWeekN = await _kpiScheduleService.GetCurrentWeekNumber();

            foreach (var item in getLessonsFromKpiApi)
            {
                SetLessonDate(item, curWeekN);

                if (!getLessonsFromDb.Contains(item))
                {
                    _lessonRepository.Add(item);
                }
            }
            return getLessonsFromKpiApi;
        }

        private static void SetLessonDate(Lesson item, int curWeekN)
        {
            var currDate = DateTime.Now;

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
    }
}
