using Microsoft.Extensions.DependencyInjection;

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

        services.AddMinimalMediator();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<MediatR.Ping>();
            cfg.AddOpenBehavior(typeof(MediatR.GenericPipelineBehavior<,>));
            cfg.AddOpenRequestPreProcessor(typeof(MediatR.GenericRequestPreProcessor<>));
            cfg.AddOpenRequestPostProcessor(typeof(MediatR.GenericRequestPostProcessor<,>));
        });

        services.AddMediator(options =>
        {
            options.Namespace = "Mediator";
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.AddSingleton(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericPipelineBehavior<,>));
        services.AddSingleton(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericPipelineBehavior<,>));
        services.AddSingleton(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericRequestPostProcessor<,>));
    }

    private static void AddMinimalMediator(this IServiceCollection services)
    {
        var assembly = typeof(Program).Assembly;
        MinimalExtensions.AddMediator(services);
        services.AddKeyedPipeline<Minimal.Mediator.PipelineConfiguration>(typeof(Minimal.Mediator.Pipeline<,>));
        services.AddRequestHandlers(assembly);
        services.AddNotificationHandlers(assembly);
    }
}
