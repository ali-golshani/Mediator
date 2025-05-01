using Microsoft.Extensions.DependencyInjection;
using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator;

internal sealed class Pipeline<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    public Pipeline(IServiceProvider serviceProvider)
        : base(serviceProvider, PipelineConfiguration.PipelineName)
    { }
}

internal sealed class PipelineConfiguration : IKeyedPipelineConfiguration
{
    public static string PipelineName { get; } = "Pipeline";

    public static MiddlewareDescriptor[] Middlewares()
    {
        return
        [
            new MiddlewareDescriptor(typeof(GenericRequestPreProcessor<,>), ServiceLifetime.Scoped),
            new MiddlewareDescriptor(typeof(GenericPipelineBehavior<,>), ServiceLifetime.Scoped),
            new MiddlewareDescriptor(typeof(GenericRequestPostProcessor<,>), ServiceLifetime.Scoped),
        ];
    }
}
