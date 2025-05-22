namespace Minimal.Mediator.Middlewares;

internal sealed class EmptyPipeline<TRequest, TResponse> : IPipeline<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> handler;

    public EmptyPipeline(IRequestHandler<TRequest, TResponse> handler)
    {
        this.handler = handler;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return handler.Handle(request, cancellationToken);
    }
}