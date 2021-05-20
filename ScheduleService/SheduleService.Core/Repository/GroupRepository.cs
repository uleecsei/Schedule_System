using Microsoft.EntityFrameworkCore;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }

        public async Task<Group> GetByName(string groupName)
        {
            return await _set.FirstOrDefaultAsync(x => x.GroupName == groupName);
        }
    }
}
