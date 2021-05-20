using ScheduleService.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository.Interfaces
{
    public interface ICurrentWeekNumberRepository : IRepository<CurrentWeekNumber>
    {
        Task SetCurrentWeek(int curWeekN);
        Task<int> GetCurrentWeek();
    }
}
