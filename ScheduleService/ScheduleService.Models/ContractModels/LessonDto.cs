using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.CoreModels.ContractModels
{
    public class LessonDto
    {
        public int lesson_id { get; set; }
        public int group_id { get; set; }
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
        public bool IsCurrentSchedule { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRemoved { get; set; }
        public ICollection<TeacherDto> Teachers { get; set; }
    }
}
