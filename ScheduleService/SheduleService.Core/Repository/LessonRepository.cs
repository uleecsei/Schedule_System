using Microsoft.EntityFrameworkCore;
using ScheduleService.Models;
using SheduleService.Core.Repository.Interfaces;

namespace SheduleService.Core.Repository
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(DbContext context) : base(context)
        {
        }
    }
}
