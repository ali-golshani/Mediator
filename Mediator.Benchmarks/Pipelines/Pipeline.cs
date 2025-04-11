using Mediator.Middlewares;

namespace Mediator.Benchmarks.Pipelines;

internal sealed class Pipeline<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    public Pipeline(IServiceProvider serviceProvider)
        : base(serviceProvider, PipelineConfiguration.PipelineName)
    { }
}
