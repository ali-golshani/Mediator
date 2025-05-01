using Minimal.Mediator.Exceptions;
using Minimal.Mediator.Extensions;
using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator;

internal sealed class Sender<TRequest, TResponse> : ISender<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    private readonly IPipeline<TRequest, TResponse> pipeline;

    public Sender(IEnumerable<IPipeline<TRequest, TResponse>> pipelines)
        : this([.. pipelines])
    { }

    private Sender(IPipeline<TRequest, TResponse>[] pipelines)
    {
        if (pipelines.Length == 0)
        {
            throw new MissingRequestPipelineException<TRequest>();
        }

        if (pipelines.Length > 1)
        {
            var pipelineTypes = pipelines.Select(x => x.GetType()).ToArray();
            throw new DuplicateRequestPipelineException<TRequest>(pipelineTypes);
        }

        pipeline = pipelines[0];
    }

    public Task<TResponse> Send(TRequest request, CancellationToken cancellationToken)
    {
        return pipeline.Handle(request.AsRequestType(), cancellationToken);
    }
}