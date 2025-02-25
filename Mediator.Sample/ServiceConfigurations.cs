using Mediator.Extensions;
using Mediator.Middlewares;
using Mediator.Sample.Middlewares;
using Mediator.Sample.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mediator.Sample;

public static class ServiceConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.RegisterRequestHandlers();

        services.RegisterValidators(typeof(ServiceConfigurations).Assembly);

        services.AddTransient(typeof(ValidationMiddleware<,>));
        services.AddTransient(typeof(ExceptionHandlingMiddleware<,>));

        services.AddTransient(typeof(IPipeline<,>), typeof(RequestPipelineA<,>));

        services.AddTransient(typeof(IPipeline<,>), typeof(RequestPipelineB<,>));
        services.RegisterMiddlewares<RequestPipelineBConfiguration>();
    }

    public static void RegisterValidators(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.Scan(scan =>
        {
            scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(FluentValidation.IValidator<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
                ;
        });
    }
}
