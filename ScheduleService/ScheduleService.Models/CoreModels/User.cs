using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.Models.CoreModels
{
    public class User : IdentityUser
    {
        public int? group_id { get; set; }
        public Group Group { get; set; }
    }
}
