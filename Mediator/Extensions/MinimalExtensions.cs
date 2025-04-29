using Minimal.Mediator;
using Minimal.Mediator.Middlewares;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class MinimalExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped(typeof(Publisher<>));
        services.AddScoped<IMediator, Mediator>();
    }

    public static void AddKeyedPipeline<TPipelineConfiguration>(
        this IServiceCollection services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type pipelineType)
        where TPipelineConfiguration : IKeyedPipelineConfiguration
    {
        services.AddScoped(typeof(IPipeline<,>), pipelineType);

        foreach (var descriptor in TPipelineConfiguration.Middlewares())
        {
            services.Add(descriptor.ServiceDescriptor(TPipelineConfiguration.PipelineName, ServiceLifetime.Scoped));
        }
    }
}
