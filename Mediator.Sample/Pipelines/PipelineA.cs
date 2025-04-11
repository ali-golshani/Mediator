using Mediator.Middlewares;
using Mediator.Sample.Requests;

namespace Mediator.Sample.Pipelines;

internal sealed class PipelineA<TRequest, TResponse> :
    KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>, IRequestA
{
    public PipelineA(IServiceProvider serviceProvider)
        : base(serviceProvider, PipelineAConfiguration.PipelineName)
    { }
}
