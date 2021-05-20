using Microsoft.EntityFrameworkCore;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleService.Core.Repository
{
    public class LessonInformationRepository : Repository<LessonInformation>, ILessonInformationRepository
    {
        public LessonInformationRepository(DbContext context) : base(context)
        {
        }
    }
}
