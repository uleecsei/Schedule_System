using ScheduleService.Models.CoreModels;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> GetByName(string groupName);
    }
}
