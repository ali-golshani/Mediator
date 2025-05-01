namespace Mediator;

public sealed class PingMiddleware : IPipelineBehavior<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public async ValueTask<Pong> Handle(Ping message, CancellationToken cancellationToken, MessageHandlerDelegate<Ping, Pong> next)
    {
        await Console.Out.WriteLineAsync($"Mediator.PingMiddleware {Id}");
        return await next(message, cancellationToken);
    }
}
