using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Sample.Extensions;
using Minimal.Mediator.Sample.Pipelines;
using Minimal.Mediator.Sample.Requests;
using System.Diagnostics.CodeAnalysis;

namespace Minimal.Mediator.Sample;

internal static class ServiceCollectionBuilder
{
    [RequiresUnreferencedCode("Calls Minimal.Mediator.Sample.ServiceCollectionBuilder.RegisterServices(IServiceCollection)")]
    public static IServiceCollection Build()
    {
        var services = new ServiceCollection();
        RegisterServices(services);
        return services;
    }

    [RequiresUnreferencedCode("Calls Microsoft.Extensions.DependencyInjection.MinimalExtensions.AddRequestHandlers(Assembly)")]
    private static void RegisterServices(IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionBuilder).Assembly;

        services.AddMediator();
        //services.RegisterHandlers(assembly);
        //services.AddRequestHandlers(assembly);
        services.AddKeyedPipeline<PipelineAConfiguration>(typeof(PipelineA<,>));
        services.AddKeyedPipeline<PipelineBConfiguration>(typeof(PipelineB<,>));

        services.AddScoped<IRequestHandler<RequestA, string>, RequestAHandler>();
        services.AddScoped<IRequestHandler<RequestB, string>, RequestBHandler>();
        services.AddScoped<IRequestHandler<SpecialRequestA, string>, SpecialRequestAHandler>();
        services.AddScoped<IRequestHandler<SpecialRequestB, string>, SpecialRequestBHandler>();

        services.RegisterValidators(assembly);
    }
}
