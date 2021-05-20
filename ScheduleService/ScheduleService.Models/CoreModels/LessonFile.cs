using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.Models.CoreModels
{
    public class LessonFile
    {
        public int FileId { get; set; }
        public string FileLink { get; set; }
        public string Name { get; set; }
        public int LessonInHistoryId { get; set; }
        public LessonInHistory LessonInHistory { get; set; }
    }
}
