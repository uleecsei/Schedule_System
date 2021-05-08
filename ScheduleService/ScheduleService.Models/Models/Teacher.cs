using System.Collections.Generic;

namespace ScheduleService.Models
{
    public class Teacher
    {
        public string teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string teacher_full_name { get; set; }
        public string teacher_short_name { get; set; }
        public string teacher_url { get; set; }
        public string teacher_rating { get; set; }

        public ICollection<TeacherOnLesson> Lessons { get; set; }
    }
}
