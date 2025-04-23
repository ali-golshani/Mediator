using Minimal.Mediator;
using Minimal.Mediator.Extensions;
using Minimal.Mediator.Middlewares;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class MinimalExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped(typeof(Publisher<>));
        services.AddScoped<IMediator, Mediator>();
    }

    public static void AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
    {
        IEnumerable<Type> assemblyTypes = assembly.DefinedTypes;
        RegisterHelpers.RegisterClassesFromAssemblyAndType(services, typeof(IRequestHandler<,>), assemblyTypes, false, false, ServiceLifetime.Scoped);
        RegisterHelpers.RegisterClassesFromAssemblyAndType(services, typeof(INotificationHandler<>), assemblyTypes, true, true, ServiceLifetime.Scoped);
    }

    public static void AddKeyedPipeline<TPipelineConfiguration>(this IServiceCollection services, Type pipelineType)
        where TPipelineConfiguration : IKeyedPipelineConfiguration
    {
        services.AddScoped(typeof(IPipeline<,>), pipelineType);

        foreach (var type in TPipelineConfiguration.Middlewares())
        {
            services.AddKeyedScoped(typeof(IMiddleware<,>), TPipelineConfiguration.PipelineName, type);
        }
    }
}
