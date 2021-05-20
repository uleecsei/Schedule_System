using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.Models.CoreModels
{
    public class Group
    {
        public int group_id { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<Lesson> Lesson { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
