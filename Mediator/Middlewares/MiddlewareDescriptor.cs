using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Minimal.Mediator.Middlewares;

public sealed class MiddlewareDescriptor(Type implementationType, Type interfaceType)
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public Type ImplementationType { get; } = implementationType;

    public Type InterfaceType { get; } = interfaceType;

    public MiddlewareDescriptor(Type implementationType)
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

    internal ServiceDescriptor ServiceDescriptor(ServiceLifetime serviceLifetime)
    {
        return new ServiceDescriptor
        (
            serviceType: InterfaceType,
            implementationType: ImplementationType,
            lifetime: serviceLifetime
        );
    }
}
