using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.Models.CoreModels
{
    public class User : IdentityUser
    {
        public string GroupName { get; set; }
    }
}
