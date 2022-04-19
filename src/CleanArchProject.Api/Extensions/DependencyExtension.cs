using Microsoft.Extensions.DependencyInjection;

namespace CleanArchProject.Api.Extensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        } 
    }
}