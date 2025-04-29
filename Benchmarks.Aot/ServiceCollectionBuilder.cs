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
        if (Program.DebugMode)
        {
            services.AddSingleton(Console.Out);
        }
        else
        {
            services.AddSingleton(TextWriter.Null);
        }

        services.AddMinimalMediator();

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
