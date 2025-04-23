using Minimal.Mediator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Benchmarks;

internal static class DIExtensions
{
    public static void RegisterRequestHandlers(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        services.RegisterRequestHandlers(assembly);
    }

    public static void RegisterRequestHandlers(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.RegisterAsImplementedInterfaces(typeof(IRequestHandler<,>), assemblies);
    }

    public static void RegisterAsImplementedInterfaces(
        this IServiceCollection services,
        Type interfaceType,
        params Assembly[] assemblies)
    {
        services.Scan(scan =>
        {
            scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(interfaceType))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                ;
        });
    }
}
