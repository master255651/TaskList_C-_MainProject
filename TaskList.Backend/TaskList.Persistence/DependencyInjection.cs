using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaskList.Application.Interfaces;

namespace TaskList.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultDatabase");
            services.AddDbContext<TaskListDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITaskListDbContext>(provider =>
                provider.GetService<TaskListDbContext>());
            return services;
        }
    }
}
