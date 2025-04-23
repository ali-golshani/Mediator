namespace Minimal.Mediator.Middlewares.Pipes;

internal sealed class LastPipe<TRequest, TResponse> :
    IRequestProcessor<TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> handler;

    public LastPipe(IRequestHandler<TRequest, TResponse> handler)
    {
        this.handler = handler;
    }

    public Task<TResponse> Handle(RequestContext<TRequest> context)
    {
        return handler.Handle(context.Request, context.CancellationToken);
    }
}