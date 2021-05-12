using Microsoft.EntityFrameworkCore;
using ScheduleService.CoreModels;
using ScheduleService.CoreModels.ContractModels;
using SheduleService.Core.DataAccess;
using SheduleService.Core.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(ScheduleSystemContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Lesson>> GetByRangeAsync(IEnumerable<int> ids)
        {
            return await _set.Include(x => x.Teachers).ThenInclude(x => x.Teacher).Where(t => ids.Contains(t.lesson_id))
                .ToListAsync();
        }
    }
}
