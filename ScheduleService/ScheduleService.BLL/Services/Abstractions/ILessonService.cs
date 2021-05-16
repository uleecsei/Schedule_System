using ScheduleService.CoreModels;
using ScheduleService.CoreModels.ContractModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services.Abstractions
{
    public interface ILessonService
    {
        Task<List<LessonDto>> GetLessons(string userId);
    }
}
