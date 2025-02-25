using Mediator.Middlewares;
using Mediator.Sample.Requests;

namespace Mediator.Sample.Pipelines;

internal sealed class RequestPipelineB<TRequest, TResponse> :
    KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>, IRequestB
{
    public RequestPipelineB(IServiceProvider serviceProvider)
        : base(serviceProvider, RequestPipelineBConfiguration.PipelineName)
    { }
}
