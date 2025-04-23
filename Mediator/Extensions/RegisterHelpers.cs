using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Minimal.Mediator.Extensions;

internal static class RegisterHelpers
{
    public static void RegisterAsImplementedInterfaces(
        IServiceCollection services,
        Assembly assembly,
        Type openGenericType,
        ServiceLifetime serviceLifetime)
    {
        var implementations = Scan(assembly, openGenericType);
        foreach (var (serviceType, implementationType) in implementations)
        {
            Register(services, serviceType, implementationType, serviceLifetime);
        }
    }

    private static void Register(IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
    {
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton(serviceType, implementationType);
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped(serviceType, implementationType);
                break;
            case ServiceLifetime.Transient:
                services.AddTransient(serviceType, implementationType);
                break;
        }
    }

    private static IEnumerable<(Type ServiceType, Type ImplementationType)> Scan(Assembly assembly, Type openGenericType)
    {
        return assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .SelectMany(t =>
                t.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == openGenericType
                    )
                    .Select(i => (ServiceType: i, ImplementationType: t))
            );
    }
}