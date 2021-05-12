using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.CoreModels.KpiScheduleModels
{
    public class KpiTeacher
    {
        public int teacher_id { get; set; }
        public string teacher_name { get; set; }
        public string teacher_full_name { get; set; }
        public string teacher_short_name { get; set; }
        public string teacher_url { get; set; }
        public string teacher_rating { get; set; }
    }
}
