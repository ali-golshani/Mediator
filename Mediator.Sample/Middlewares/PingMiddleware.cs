using Minimal.Mediator.Middlewares;
using Minimal.Mediator.Sample.Requests;

namespace Minimal.Mediator.Sample.Middlewares;

public sealed class PingMiddleware : IMiddleware<Ping, Pong>
{
    private static int iteration = 0;

    public readonly int Id = Interlocked.Increment(ref iteration);

    public async Task<Pong> Handle(RequestContext<Ping> context, IRequestProcessor<Ping, Pong> next)
    {
        Console.WriteLine($"Middleware :: PingMiddleware {Id}");

        return await next.Handle(context);
    }
}