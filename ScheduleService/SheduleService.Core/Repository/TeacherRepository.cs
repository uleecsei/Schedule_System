using Microsoft.EntityFrameworkCore;
using ScheduleService.CoreModels;
using SheduleService.Core.DataAccess;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleService.Core.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ScheduleSystemContext context) : base(context)
        {
        }
    }
}
