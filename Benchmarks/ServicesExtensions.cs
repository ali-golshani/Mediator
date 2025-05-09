﻿using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator;
using System.Reflection;

namespace Benchmarks;

public static class ServicesExtensions
{
    public static readonly Assembly Assembly = typeof(ServicesExtensions).Assembly;

    public static void AddRequestHandlers(this IServiceCollection services)
    {
        services.RegisterAsImplementedInterfaces(typeof(IRequestHandler<,>), Assembly);
    }

    public static void AddNotificationHandlers(this IServiceCollection services)
    {
        services.RegisterAsImplementedInterfaces(typeof(INotificationHandler<>), Assembly);
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
                .AddClasses(classes => classes.AssignableTo(interfaceType), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
    }
}
