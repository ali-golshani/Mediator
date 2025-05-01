namespace MediatR;

public sealed class PingMiddleware : IPipelineBehavior<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public async Task<Pong> Handle(Ping request, RequestHandlerDelegate<Pong> next, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"MediatR.PingMiddleware {Id}");
        return await next(cancellationToken);
    }
}
