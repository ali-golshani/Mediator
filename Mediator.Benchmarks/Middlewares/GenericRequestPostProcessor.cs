using Mediator.Middlewares;

namespace Mediator.Benchmarks.Middlewares;

public class GenericRequestPostProcessor<TRequest, TResponse>(TextWriter writer) : IMiddleware<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        var response = await next.Handle(context);
        await writer.WriteLineAsync("- All Done");
        return response;
    }
}
