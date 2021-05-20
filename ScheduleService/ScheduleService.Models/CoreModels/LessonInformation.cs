using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.Models.CoreModels
{
    public class LessonInformation
    {
        public int LessonInformationId { get; set; }
        public int LessonInHistoryId { get; set; }
        public string Description { get; set; }
        public string ConferenceUrl { get; set; }
        public LessonInHistory LessonInHistory { get; set; }
    }
}
