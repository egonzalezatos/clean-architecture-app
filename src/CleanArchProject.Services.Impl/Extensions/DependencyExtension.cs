using System;
using System.Linq;
using System.Reflection;
using CleanArchProject.Services.Impl.Services;
using CleanArchProject.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchProject.Services.Impl.Extensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var type = typeof(IService);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            var servicesImpl = types.Where(type => !type.IsInterface);
            foreach (var serviceImpl in servicesImpl)
            {
                services.AddScoped(serviceImpl.GetTypeInfo().GetInterface($"I{serviceImpl.Name}")!, serviceImpl);
            }
            foreach (var service in servicesImpl) Console.WriteLine(service.Name);
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyExtension));
            return services;
        }
    }
}