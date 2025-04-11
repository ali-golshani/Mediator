using Mediator.Benchmarks.Extensions;
using Mediator.Benchmarks.Pipelines;
using Mediator.Extensions;
using Mediator.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Benchmarks;

public static class ServiceConfigurations
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton(TextWriter.Null);
        services.RegisterRequestHandlers();
        services.RegisterPipelines();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<MediatR.Benchmarks.Ping>();
            cfg.AddOpenBehavior(typeof(MediatR.Benchmarks.GenericPipelineBehavior<,>));
            cfg.AddOpenRequestPreProcessor(typeof(MediatR.Benchmarks.GenericRequestPreProcessor<>));
            cfg.AddOpenRequestPostProcessor(typeof(MediatR.Benchmarks.GenericRequestPostProcessor<,>));
        });
    }

    private static void RegisterPipelines(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipeline<,>), typeof(Pipeline<,>));
        services.RegisterMiddlewares<PipelineConfiguration>();
    }
}
