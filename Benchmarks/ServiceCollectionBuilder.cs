using Mediator;
using Mediator.Extensions;
using Mediator.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

public static class ServiceCollectionBuilder
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

        services.AddMediator();
        services.RegisterRequestHandlers();
        services.RegisterPipelines();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<MediatR.Ping>();
            cfg.AddOpenBehavior(typeof(MediatR.GenericPipelineBehavior<,>));
            cfg.AddOpenRequestPreProcessor(typeof(MediatR.GenericRequestPreProcessor<>));
            cfg.AddOpenRequestPostProcessor(typeof(MediatR.GenericRequestPostProcessor<,>));
        });
    }

    private static void RegisterPipelines(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipeline<,>), typeof(Pipeline<,>));
        services.RegisterMiddlewares<PipelineConfiguration>();
    }
}
