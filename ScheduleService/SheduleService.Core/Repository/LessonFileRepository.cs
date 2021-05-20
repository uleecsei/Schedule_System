using Microsoft.EntityFrameworkCore;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleService.Core.Repository
{
    public class LessonFileRepository : Repository<LessonFile>, ILessonFileRepository
    {
        public LessonFileRepository(DbContext context) : base(context)
        {
        }
    }
}
