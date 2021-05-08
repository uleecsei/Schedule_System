using ScheduleService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services.Abstractions
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetLessons(string groupName);
    }
}
