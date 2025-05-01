using Microsoft.Extensions.DependencyInjection;

namespace ServiceLifetimes;

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
            cfg.Lifetime = ServiceLifetime.Transient;
            cfg.RegisterServicesFromAssemblyContaining<Ping>();
            cfg.AddBehavior<PingMiddleware>(ServiceLifetime.Transient);
        });
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.Namespace = "Mediator";
            options.ServiceLifetime = ServiceLifetime.Transient;
        });

        services.AddScoped(typeof(Mediator.IPipelineBehavior<Ping, Pong>), typeof(PingMiddleware));
    }

    private static void AddMinimalMediator(this IServiceCollection services)
    {
        MinimalExtensions.AddMediator(services);
        services.AddRequestHandlers();
        services.AddKeyedPipeline<PingPipeline.Configuration>(typeof(PingPipeline.Pipeline<,>));
    }
}
