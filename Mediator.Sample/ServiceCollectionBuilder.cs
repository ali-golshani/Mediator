using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Extensions;
using Minimal.Mediator.Sample.Pipelines;

namespace Minimal.Mediator.Sample;

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
        services.AddMediator();
        services.RegisterRequestHandlers();
        services.RegisterValidators();
        services.RegisterPipelines();
    }

    private static void RegisterPipelines(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipeline<,>), typeof(PipelineA<,>));
        services.AddMiddlewares<PipelineAConfiguration>();

        services.AddTransient(typeof(IPipeline<,>), typeof(PipelineB<,>));
        services.AddMiddlewares<PipelineBConfiguration>();
    }
}
