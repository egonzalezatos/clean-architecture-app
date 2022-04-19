using CleanArchProject.Services.Impl.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchProject.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddCleanArchProjectDependencies(this IServiceCollection services)
        {
            services.AddServices();
            services.AddMappers();
            return services;
        }
    }
}