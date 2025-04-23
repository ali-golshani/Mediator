using Minimal.Mediator.Middlewares;

namespace Minimal.Mediator.Sample.Middlewares;

public sealed class MiddlewareB<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        Console.WriteLine("Middleware :: MiddlewareB");

        return await next.Handle(context);
    }
}