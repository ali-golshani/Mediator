namespace Minimal.Mediator.Middlewares.Pipes;

internal sealed class FilterPipe<TRequest, TResponse>(IMiddleware<TRequest, TResponse> filter, IRequestProcessor<TRequest, TResponse> pipe)
    : IRequestProcessor<TRequest, TResponse>
{
    private readonly IMiddleware<TRequest, TResponse> filter = filter;
    private readonly IRequestProcessor<TRequest, TResponse> pipe = pipe;

    public Task<TResponse> Handle(RequestContext<TRequest> context)
    {
        return filter.Handle(context, pipe);
    }
}
