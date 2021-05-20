using Microsoft.EntityFrameworkCore;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository
{
    public class CurrentWeekNumberRepository : Repository<CurrentWeekNumber>, ICurrentWeekNumberRepository
    {
        public CurrentWeekNumberRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GetCurrentWeek()
        {
            return (await _set.FirstOrDefaultAsync()).Number;
        }

        public async Task SetCurrentWeek(int curWeekN)
        {
            var weekNumber = await _set.FirstOrDefaultAsync();
            weekNumber.Number = curWeekN;
        }
    }
}
