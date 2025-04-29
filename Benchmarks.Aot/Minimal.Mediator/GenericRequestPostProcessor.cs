using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator;

internal class GenericRequestPostProcessor<TRequest, TResponse>(TextWriter writer) : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        var response = await next.Handle(context);
        await writer.WriteLineAsync("- All Done");
        return response;
    }
}
