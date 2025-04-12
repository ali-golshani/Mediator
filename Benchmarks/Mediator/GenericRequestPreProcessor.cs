using Mediator.Middlewares;

namespace Mediator;

internal class GenericRequestPreProcessor<TRequest, TResponse>(TextWriter writer) : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        await writer.WriteLineAsync("- Starting Up");
        return await next.Handle(context);
    }
}
