using Minimal.Mediator;
using Minimal.Mediator.Middlewares;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class MinimalExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddTransient(typeof(Publisher<>));
        services.AddScoped<IMediator, Mediator>();
    }

    public static void AddKeyedPipeline<TPipelineConfiguration>(
        this IServiceCollection services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type pipelineType,
        ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        where TPipelineConfiguration : IKeyedPipelineConfiguration
    {
        services.Add(new ServiceDescriptor(typeof(IPipeline<,>), pipelineType, serviceLifetime));

        foreach (var descriptor in TPipelineConfiguration.Middlewares())
        {
            services.Add(descriptor.ServiceDescriptor(TPipelineConfiguration.PipelineName));
        }
    }
}
