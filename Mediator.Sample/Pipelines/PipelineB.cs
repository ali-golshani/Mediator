using Mediator.Middlewares;
using Mediator.Sample.Requests;

namespace Mediator.Sample.Pipelines;

internal sealed class PipelineB<TRequest, TResponse> :
    KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>, IRequestB
{
    public PipelineB(IServiceProvider serviceProvider)
        : base(serviceProvider, PipelineBConfiguration.PipelineName)
    { }
}
