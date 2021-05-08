using ScheduleService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiScheduleCore.Services.Interfaces
{
    public interface IKpiScheduleService
    {
        Task<List<Lesson>> GetGroupLessonsList(string groupName);
        Task<int> GetCurrentWeekNumber();
    }
}
