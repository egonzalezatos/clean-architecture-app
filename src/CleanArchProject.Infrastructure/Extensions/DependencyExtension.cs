using CleanArchProject.Domain.Repositories;
using CleanArchProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchProject.Infrastructure.Extensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, bool isDevelopment, string connectionString)
        {
            services.AddContext(isDevelopment, connectionString);
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services,  bool isDevelopment, string connectionString)
        {
            if (isDevelopment)
                services.AddDbContext<EntityContext>(options => options.UseInMemoryDatabase("DB_Name"));
            else
                services.AddDbContext<EntityContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddScoped<ISubplantRepository, SubplantRepository>();
            return services;
        }
    }
}