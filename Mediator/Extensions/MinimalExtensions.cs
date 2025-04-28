using Minimal.Mediator;
using Minimal.Mediator.Extensions;
using Minimal.Mediator.Middlewares;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class MinimalExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped(typeof(Publisher<>));
        services.AddScoped<IMediator, Mediator>();
    }

    public static void AddRequestHandlers(this IServiceCollection services, Assembly assembly)
    {
        RegisterHelpers.RegisterAsImplementedInterfaces(services, assembly, typeof(IRequestHandler<,>), ServiceLifetime.Scoped);
    }

    public static void AddNotificationHandlers(this IServiceCollection services, Assembly assembly)
    {
        RegisterHelpers.RegisterAsImplementedInterfaces(services, assembly, typeof(INotificationHandler<>), ServiceLifetime.Scoped);
    }

    public static void AddKeyedPipeline<TPipelineConfiguration>(
        this IServiceCollection services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type pipelineType)
        where TPipelineConfiguration : IKeyedPipelineConfiguration
    {
        services.AddScoped(typeof(IPipeline<,>), pipelineType);

        foreach (var descriptor in TPipelineConfiguration.Middlewares())
        {
            services.Add(descriptor.ServiceDescriptor(ServiceLifetime.Scoped));
        }
    }
}
