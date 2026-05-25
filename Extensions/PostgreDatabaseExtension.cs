using Import_Export_Company.Data;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Extensions
{
    public static class PostgreDatabaseExtension
    {
        public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            //services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
