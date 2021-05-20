using System.Collections.Generic;

namespace ScheduleService.Models.CoreModels
{
    public class Teacher
    {
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string teacher_full_name { get; set; }
        public string teacher_short_name { get; set; }
        public string teacher_url { get; set; }
        public string teacher_rating { get; set; }

        public ICollection<TeacherOnLesson> Lessons { get; set; }
    }
}
