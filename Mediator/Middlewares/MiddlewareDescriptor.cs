using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Minimal.Mediator.Middlewares;

public sealed class MiddlewareDescriptor
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public Type ImplementationType { get; }

    public Type InterfaceType { get; }
    public ServiceLifetime ServiceLifetime { get; }

    public MiddlewareDescriptor(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
        Type interfaceType,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        ImplementationType = implementationType;
        InterfaceType = interfaceType;
        ServiceLifetime = serviceLifetime;
    }

    public MiddlewareDescriptor(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        : this(implementationType, typeof(IMiddleware<,>), serviceLifetime)
    { }

    public static implicit operator MiddlewareDescriptor(Type implementationType)
    {
        return new MiddlewareDescriptor(implementationType);
    }

    internal ServiceDescriptor ServiceDescriptor(string serviceKey)
    {
        return new ServiceDescriptor
        (
            serviceType: InterfaceType,
            serviceKey: serviceKey,
            implementationType: ImplementationType,
            lifetime: ServiceLifetime
        );
    }
}
