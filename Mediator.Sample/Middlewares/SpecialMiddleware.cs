using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Requests;

namespace Minimal.Mediator.Sample.Middlewares;

public sealed class SpecialMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
    where TRequest : ISpecialRequest
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        Console.WriteLine("Middleware :: SpecialMiddleware");

        return await next.Handle(context);
    }
}