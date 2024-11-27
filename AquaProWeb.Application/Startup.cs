using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AquaProWeb.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assembly);
            });

        }

    }
}
