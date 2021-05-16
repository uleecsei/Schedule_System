using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Models.CoreModels;
using SheduleService.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleService.BLL.Extentions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection SetUpIdentity(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ScheduleSystemContext>();
            builder.AddRoleValidator<RoleValidator<IdentityRole>>();
            builder.AddRoleManager<RoleManager<IdentityRole>>();
            builder.AddSignInManager<SignInManager<User>>();

            return services;
        }
    }
}
