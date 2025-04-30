using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Requests;

namespace Minimal.Mediator.Sample.Middlewares;

public sealed class PingMiddleware : IMiddleware<Ping, Pong>
{
    public async Task<Pong> Handle(RequestContext<Ping> context, IRequestProcessor<Ping, Pong> next)
    {
        Console.WriteLine("Middleware :: PingMiddleware");

        return await next.Handle(context);
    }
}