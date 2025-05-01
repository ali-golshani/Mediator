namespace ServiceLifetimes;

public sealed class PingMiddleware :
    Minimal.Mediator.Middlewares.IMiddleware<Ping, Pong>,
    MediatR.IPipelineBehavior<Ping, Pong>,
    Mediator.IPipelineBehavior<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public async Task<Pong> Handle(Minimal.Mediator.Middlewares.RequestContext<Ping> context, Minimal.Mediator.Middlewares.IRequestProcessor<Ping, Pong> next)
    {
        await Console.Out.WriteLineAsync($"Minimal.Mediator.PingMiddleware {Id}");
        return await next.Handle(context);
    }

    public async Task<Pong> Handle(Ping request, MediatR.RequestHandlerDelegate<Pong> next, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"MediatR.PingMiddleware {Id}");
        return await next(cancellationToken);
    }

    public async ValueTask<Pong> Handle(Ping message, CancellationToken cancellationToken, Mediator.MessageHandlerDelegate<Ping, Pong> next)
    {
        await Console.Out.WriteLineAsync($"Mediator.PingMiddleware {Id}");
        return await next(message, cancellationToken);
    }
}
