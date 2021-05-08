using System;
using System.Collections.Generic;

namespace ScheduleService.Models
{
    public class Lesson
    {
        public string lesson_id { get; set; }
        public string group_id { get; set; }
        public string day_number { get; set; }
        public string day_name { get; set; }
        public string lesson_name { get; set; }
        public string lesson_full_name { get; set; }
        public string lesson_number { get; set; }
        public string lesson_room { get; set; }
        public string lesson_type { get; set; }
        public string teacher_name { get; set; }
        public string lesson_week { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
        public DateTime lesson_date { get; set; }
        public ICollection<TeacherOnLesson> Teachers { get; set; }
    }
}
