using Microsoft.Extensions.DependencyInjection;
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
        var assembly = typeof(Program).Assembly;

        services.AddMediator();
        services.AddRequestHandlers(assembly);
        services.AddKeyedPipeline<PipelineAConfiguration>(typeof(PipelineA<,>));
        services.AddKeyedPipeline<PipelineBConfiguration>(typeof(PipelineB<,>));

        services.RegisterValidators(assembly);
    }
}
