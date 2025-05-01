namespace MediatR;

public sealed class Ping : IRequest<Pong>
{
    private static int iteration = 0;
    public readonly int Id = Interlocked.Increment(ref iteration);

    public override string ToString() => $"Ping {Id}";
}
