using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR;

internal static class Registry
{
    public static readonly ServiceLifetime Lifetime = ServiceLifetime.Scoped;
    public static readonly ServiceLifetime MiddlewareLifetime = ServiceLifetime.Scoped;

    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = Lifetime;
            cfg.RegisterServicesFromAssemblyContaining<Ping>();
            cfg.AddBehavior<PingMiddleware>(MiddlewareLifetime);
        });
    }
}