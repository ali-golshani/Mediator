using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Sample.Pipelines;
using ServiceScan;

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
        services.AddRequestHandlers();
        services.AddKeyedPipeline<PipelineA.Configuration>(typeof(PipelineA.Pipeline<,>));
        services.AddKeyedPipeline<PipelineB.Configuration>(typeof(PipelineB.Pipeline<,>));

        services.AddValidators();
    }
}
