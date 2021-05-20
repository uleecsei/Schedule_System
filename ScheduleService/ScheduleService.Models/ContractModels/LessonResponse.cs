using ScheduleService.CoreModels.ContractModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.Models.ContractModels
{
    public class LessonResponse
    {
        public List<LessonDto> Lessons { get; set; }
        public int CurrentWeekNumber { get; set; }
    }
}
