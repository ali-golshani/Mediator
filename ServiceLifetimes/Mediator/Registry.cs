using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator;

internal static class Registry
{
    public static readonly ServiceLifetime Lifetime = ServiceLifetime.Scoped;
    public static readonly ServiceLifetime MiddlewareLifetime = ServiceLifetime.Scoped;

    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.Namespace = "Mediator";
            options.ServiceLifetime = Lifetime;
        });

        services.Add(new ServiceDescriptor(typeof(IPipelineBehavior<Ping, Pong>), typeof(PingMiddleware), MiddlewareLifetime));
    }
}