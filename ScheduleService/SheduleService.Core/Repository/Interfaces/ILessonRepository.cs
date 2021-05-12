using ScheduleService.CoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> GetByRangeAsync(IEnumerable<int> ids);
    }
}
