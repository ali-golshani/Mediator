using Mediator.Middlewares;

namespace Mediator.Benchmarks.Middlewares;

public class GenericPipelineBehavior<TRequest, TResponse>(TextWriter writer) : IMiddleware<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        await writer.WriteLineAsync("-- Handling Request");
        var response = await next.Handle(context);
        await writer.WriteLineAsync("-- Finished Request");
        return response;
    }
}
