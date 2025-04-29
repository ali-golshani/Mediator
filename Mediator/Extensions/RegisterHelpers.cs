using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Minimal.Mediator.Extensions;

internal static class RegisterHelpers
{
    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.GetTypes()")]
    public static void RegisterAsImplementedInterfaces(
        IServiceCollection services,
        Assembly assembly,
        Type openGenericType,
        ServiceLifetime serviceLifetime)
    {
        var implementations = Scan(assembly, openGenericType);
        foreach (var (serviceType, implementationType) in implementations)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, serviceLifetime);
            services.Add(descriptor);
        }
    }

    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.GetTypes()")]
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