using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator;
using System.Reflection;

namespace ServiceLifetimes;

public static class ServicesExtensions
{
    public static readonly Assembly Assembly = typeof(ServicesExtensions).Assembly;

    public static void AddRequestHandlers(this IServiceCollection services, ServiceLifetime serviceLifetime)
    {
        services.RegisterAsImplementedInterfaces(typeof(IRequestHandler<,>), serviceLifetime, Assembly);
    }

    public static void RegisterAsImplementedInterfaces(
        this IServiceCollection services,
        Type interfaceType,
        ServiceLifetime serviceLifetime,
        params Assembly[] assemblies)
    {
        services.Scan(scan =>
        {
            scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(interfaceType), publicOnly: false)
                .AsImplementedInterfaces()
                .WithLifetime(serviceLifetime);
        });
    }
}
