using AquaProWeb.Application.Repositories;
using AquaProWeb.Infrastructure.Contexts;
using AquaProWeb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AquaProWeb.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), sqlserver => sqlserver.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName).UseNetTopologySuite()));



        }

        public static IServiceCollection AddConfigurationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ConfigDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConfigurationConnectionString")));
        }

        public static IServiceCollection AddAuthorizationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AuthConnectionString")));
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IReadRepositoryAsync<>), typeof(ReadRepositoryAsync<>))
                .AddTransient(typeof(IWriteRepositoryAsync<>), typeof(WriteRepositoryAsync<>))
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
