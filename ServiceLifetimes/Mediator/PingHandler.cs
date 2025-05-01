namespace Mediator;

public sealed class PingHandler : IRequestHandler<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public async ValueTask<Pong> Handle(Ping request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"Mediator.PingHandler {Id}");
        return await ValueTask.FromResult(new Pong(request.ToString()));
    }
}
