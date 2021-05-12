using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ScheduleService.BLL.Extentions
{
    public static class HostExtensions
    {
        public static IHost MigrateDbContext<TContext>(
            this IHost host)
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                context.Database.Migrate();
            }

            return host;
        }
    }
}
