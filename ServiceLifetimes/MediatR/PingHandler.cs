namespace MediatR;

public sealed class PingHandler : IRequestHandler<Ping, Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    async Task<Pong> IRequestHandler<Ping, Pong>.Handle(Ping request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"MediatR.PingHandler {Id}");
        return await Task.FromResult(new Pong(request.ToString()));
    }
}
