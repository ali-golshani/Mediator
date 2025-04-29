using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator;

internal class GenericPipelineBehavior<TRequest, TResponse>(TextWriter writer) : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        await writer.WriteLineAsync("-- Handling Request");
        var response = await next.Handle(context);
        await writer.WriteLineAsync("-- Finished Request");
        return response;
    }
}
