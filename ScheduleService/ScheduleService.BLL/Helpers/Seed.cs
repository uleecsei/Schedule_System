using Microsoft.AspNetCore.Identity;
using ScheduleService.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleService.BLL.Helpers
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRole()
        {
            if (!_roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole {Name = "Admin"},
                    new IdentityRole {Name = "Teacher"},
                    new IdentityRole {Name = "Student"}
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }
            }
        }

        public void SeedAdmin()
        {
            if (_userManager.Users.FirstOrDefault(p => p.UserName == "Admin") == null)
            {
                var adminUser = new User
                {
                    UserName = "Admin",
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
                }
            }
            if (_userManager.Users.FirstOrDefault(p => p.UserName == "Student") == null)
            {
                var user = new User
                {
                    UserName = "Student",
                    group_id = 1893
                };

                IdentityResult result = _userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Student").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Student" }).Wait();
                }
            }
            if (_userManager.Users.FirstOrDefault(p => p.UserName == "Teacher") == null)
            {
                var user = new User
                {
                    UserName = "Teacher",
                };

                IdentityResult result = _userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Teacher").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Teacher" }).Wait();
                }
            }
        }
    }
}
