using AquaProWeb.Application.Behaviors;
using AquaProWeb.Application.Features.Abonats.Ubicacions.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AquaProWeb.Application
{
    public static class Startup
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(assembly); });

        }

        public static IServiceCollection AddApplicationValidation(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //return services.AddValidatorsFromAssemblyContaining<AquaProWeb.Application.Features.Abonats.Ubicacions.Commands.CreateUbicacioCommandValidator>();
            return services.AddValidatorsFromAssemblyContaining<CreateUbicacioCommandValidator>();

        }

        public static IServiceCollection AddValidationPipeline(this IServiceCollection services)
        {

            return services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }
    }
}
