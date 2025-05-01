namespace Minimal.Mediator;

public sealed class PingMiddleware : Middlewares.IMiddleware<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public async Task<Pong> Handle(Middlewares.RequestContext<Ping> context, Middlewares.IRequestProcessor<Ping, Pong> next)
    {
        await Console.Out.WriteLineAsync($"Minimal.Mediator.PingMiddleware {Id}");
        return await next.Handle(context);
    }
}
