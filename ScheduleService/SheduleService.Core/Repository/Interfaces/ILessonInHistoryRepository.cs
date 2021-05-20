using ScheduleService.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository.Interfaces
{
    public interface ILessonInHistoryRepository : IRepository<LessonInHistory>
    {
        Task<LessonInHistory> GetByLessonIdAndDate(int lessonId, DateTime date);
    }
}
