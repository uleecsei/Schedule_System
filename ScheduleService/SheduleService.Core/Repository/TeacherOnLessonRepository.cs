using Microsoft.EntityFrameworkCore;
using ScheduleService.CoreModels;
using SheduleService.Core.DataAccess;
using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleService.Core.Repository
{
    public class TeacherOnLessonRepository : Repository<TeacherOnLesson>, ITeacherOnLessonRepository
    {
        public TeacherOnLessonRepository(ScheduleSystemContext context) : base(context)
        {
        }
    }
}
