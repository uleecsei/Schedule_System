using ScheduleService.CoreModels;
using ScheduleService.CoreModels.KpiScheduleModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpiScheduleCore.Services.Interfaces
{
    public interface IKpiScheduleService
    {
        Task<List<KpiLesson>> GetGroupLessonsList(string groupName);
        Task<int> GetCurrentWeekNumber();
    }
}
