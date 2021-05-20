using ScheduleService.CoreModels;
using ScheduleService.CoreModels.ContractModels;
using ScheduleService.Models.ContractModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services.Abstractions
{
    public interface ILessonService
    {
        Task<LessonResponse> GetLessons(string userId);
        Task<bool> PostLessonInformation(int lessonId, DateTime date, LessonInforamtionDto informationDto);
        Task<bool> PostLessonFile(int lessonId, DateTime date, LessonFileDto lessonFile);
    }
}
