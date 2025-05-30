﻿using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

internal static class ServiceCollectionBuilder
{
    public static IServiceCollection Build()
    {
        var services = new ServiceCollection();
        RegisterServices(services);
        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton(TextWriter.Null);

        services.AddMediatR();
        services.AddMediator();
        services.AddMinimalMediator();
    }

    private static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssemblyContaining<MediatR.Ping>();
            cfg.AddOpenBehavior(typeof(MediatR.GenericPipelineBehavior<,>), ServiceLifetime.Scoped);
            cfg.AddOpenRequestPreProcessor(typeof(MediatR.GenericRequestPreProcessor<>), ServiceLifetime.Scoped);
            cfg.AddOpenRequestPostProcessor(typeof(MediatR.GenericRequestPostProcessor<,>), ServiceLifetime.Scoped);
        });
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.Namespace = "Mediator";
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.AddScoped(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericRequestPreProcessor<,>));
        services.AddScoped(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericPipelineBehavior<,>));
        services.AddScoped(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericRequestPostProcessor<,>));
    }

    private static void AddMinimalMediator(this IServiceCollection services)
    {
        MinimalExtensions.AddMediator(services);
        services.AddRequestHandlers();
        services.AddNotificationHandlers();
        services.AddKeyedPipeline<Minimal.Mediator.PipelineConfiguration>(typeof(Minimal.Mediator.Pipeline<,>), ServiceLifetime.Scoped);
    }
}
