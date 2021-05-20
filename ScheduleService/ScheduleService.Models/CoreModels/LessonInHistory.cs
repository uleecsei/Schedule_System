using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScheduleService.Models.CoreModels
{
    public class LessonInHistory
    {
        public int LessonInHistoryId { get; set; }
        public int lesson_id { get; set; }
        [Column(TypeName = "date")]
        public DateTime lesson_date { get; set; }
        public LessonInformation LessonInformation { get; set; }
        public IEnumerable<LessonFile> LessonFile { get; set; }
        public Lesson Lesson { get; set; }
    }
}
