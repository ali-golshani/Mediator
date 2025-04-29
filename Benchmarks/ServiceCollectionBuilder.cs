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

        services.AddMediatR();
        services.AddMediator();
        services.AddMinimalMediator();
    }

    private static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<MediatR.Ping>();
            cfg.AddOpenBehavior(typeof(MediatR.GenericPipelineBehavior<,>));
            cfg.AddOpenRequestPreProcessor(typeof(MediatR.GenericRequestPreProcessor<>));
            cfg.AddOpenRequestPostProcessor(typeof(MediatR.GenericRequestPostProcessor<,>));
        });
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.Namespace = "Mediator";
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.AddSingleton(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericRequestPreProcessor<,>));
        services.AddSingleton(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericPipelineBehavior<,>));
        services.AddSingleton(typeof(Mediator.IPipelineBehavior<,>), typeof(Mediator.GenericRequestPostProcessor<,>));
    }

    private static void AddMinimalMediator(this IServiceCollection services)
    {
        MinimalExtensions.AddMediator(services);
        services.AddRequestHandlers();
        services.AddNotificationHandlers();
        services.AddKeyedPipeline<Minimal.Mediator.PipelineConfiguration>(typeof(Minimal.Mediator.Pipeline<,>));
    }
}
