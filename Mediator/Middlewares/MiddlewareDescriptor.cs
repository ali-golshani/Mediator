using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Minimal.Mediator.Middlewares;

public sealed class MiddlewareDescriptor
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public Type ImplementationType { get; }

    public Type InterfaceType { get; }

    public MiddlewareDescriptor(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
        Type interfaceType)
    {
        ImplementationType = implementationType;
        InterfaceType = interfaceType;
    }

    public MiddlewareDescriptor(
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        : this(implementationType, typeof(IMiddleware<,>))
    { }

    public static implicit operator MiddlewareDescriptor((Type ImplementationType, Type InterfaceType) tuple)
    {
        return new MiddlewareDescriptor(tuple.ImplementationType, tuple.InterfaceType);
    }

    public static implicit operator MiddlewareDescriptor(Type implementationType)
    {
        return new MiddlewareDescriptor(implementationType);
    }

    internal ServiceDescriptor ServiceDescriptor(string serviceKey, ServiceLifetime serviceLifetime)
    {
        return new ServiceDescriptor
        (
            serviceType: InterfaceType,
            serviceKey: serviceKey,
            implementationType: ImplementationType,
            lifetime: serviceLifetime
        );
    }
}
