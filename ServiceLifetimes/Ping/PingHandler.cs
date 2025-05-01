namespace ServiceLifetimes;

public sealed class PingHandler :
    Minimal.Mediator.IRequestHandler<Ping, Pong>,
    MediatR.IRequestHandler<Ping, Pong>,
    Mediator.IRequestHandler<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    async Task<Pong> Minimal.Mediator.IRequestHandler<Ping, Pong>.Handle(Ping request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"Minimal.Mediator.PingHandler {Id}");
        return await Task.FromResult(new Pong(request.ToString()));
    }

    async Task<Pong> MediatR.IRequestHandler<Ping, Pong>.Handle(Ping request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"MediatR.PingHandler {Id}");
        return await Task.FromResult(new Pong(request.ToString()));
    }

    async ValueTask<Pong> Mediator.IRequestHandler<Ping, Pong>.Handle(Ping request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"Mediator.PingHandler {Id}");
        return await ValueTask.FromResult(new Pong(request.ToString()));
    }
}
