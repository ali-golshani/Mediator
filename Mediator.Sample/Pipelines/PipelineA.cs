using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Requests;

namespace Minimal.Mediator.Sample.Pipelines;

internal sealed class PipelineA<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>, IRequestA
{
    public PipelineA(IServiceProvider serviceProvider)
        : base(serviceProvider, PipelineAConfiguration.PipelineName)
    { }
}
