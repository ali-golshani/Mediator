namespace ServiceLifetimes;

public sealed class Ping :
    Minimal.Mediator.IRequest<Ping, Pong>,
    MediatR.IRequest<Pong>,
    Mediator.IRequest<Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public override string ToString() => $"Ping {Id}";
}
