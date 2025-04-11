using Mediator.Middlewares;

namespace Mediator.Sample.Middlewares;

public sealed class MiddlewareA<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        Console.WriteLine("Middleware :: MiddlewareA");

        return await next.Handle(context);
    }
}