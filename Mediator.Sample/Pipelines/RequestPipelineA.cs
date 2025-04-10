using Mediator.Middlewares;
using Mediator.Sample.Requests;

namespace Mediator.Sample.Pipelines;

internal sealed class RequestPipelineA<TRequest, TResponse> :
    KeyedPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>, IRequestA
{
    public RequestPipelineA(IServiceProvider serviceProvider)
        : base(serviceProvider, RequestPipelineAConfiguration.PipelineName)
    { }
}
