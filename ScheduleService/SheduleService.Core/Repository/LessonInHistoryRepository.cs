using Microsoft.EntityFrameworkCore;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository
{
    public class LessonInHistoryRepository : Repository<LessonInHistory>, ILessonInHistoryRepository
    {
        public LessonInHistoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<LessonInHistory> GetByLessonIdAndDate(int lessonId, DateTime date)
        {
            return await _set.Where(x => x.lesson_id == lessonId && x.lesson_date == date).FirstOrDefaultAsync();
        }
    }
}
