using Microsoft.EntityFrameworkCore;
using ScheduleService.CoreModels.ContractModels;
using ScheduleService.Models.CoreModels;
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

        public async Task<IEnumerable<Lesson>> GetLessonsBuGroupId(int group_id)
        {
            return await _set.Include(x => x.Teachers).ThenInclude(x => x.Teacher).Where(x => x.group_id == group_id)
                .ToListAsync();
        }
    }
}
