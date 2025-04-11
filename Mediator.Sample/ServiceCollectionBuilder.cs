using Mediator.Extensions;
using Mediator.Middlewares;
using Mediator.Sample.Extensions;
using Mediator.Sample.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Sample;

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
        services.AddMediator();
        services.RegisterRequestHandlers();
        services.RegisterValidators();
        services.RegisterPipelines();
    }

    private static void RegisterPipelines(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipeline<,>), typeof(PipelineA<,>));
        services.RegisterMiddlewares<PipelineAConfiguration>();

        services.AddTransient(typeof(IPipeline<,>), typeof(PipelineB<,>));
        services.RegisterMiddlewares<PipelineBConfiguration>();
    }
}
