using Microsoft.Extensions.DependencyInjection;
using ServiceLifetimes;

namespace Minimal.Mediator;

internal static class Registry
{
    public static readonly ServiceLifetime PipelineLifetime = ServiceLifetime.Scoped;
    public static readonly ServiceLifetime MiddlewareLifetime = ServiceLifetime.Scoped;
    public static readonly ServiceLifetime HandlerLifetime = ServiceLifetime.Scoped;

    public static void AddMinimalMediator(this IServiceCollection services)
    {
        MinimalExtensions.AddMediator(services);
        services.AddRequestHandlers(HandlerLifetime);
        services.AddKeyedPipeline<PingPipeline.Configuration>(typeof(PingPipeline.Pipeline<,>), PipelineLifetime);
    }
}