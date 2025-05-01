using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR;

internal static class Registry
{
    public static readonly ServiceLifetime Lifetime = ServiceLifetime.Transient;
    public static readonly ServiceLifetime MiddlewareLifetime = ServiceLifetime.Transient;

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