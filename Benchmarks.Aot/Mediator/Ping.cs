namespace Mediator;

public sealed class Pong(int value)
{
    public int Value { get; } = value;
}

public sealed class Ping : IRequest<Pong>
{
    public required string Message { get; set; }
}

internal sealed class PingHandler : IRequestHandler<Ping, Pong>
{
    ValueTask<Pong> IRequestHandler<Ping, Pong>.Handle(Ping request, CancellationToken cancellationToken) => ValueTask.FromResult(new Pong(request.Message.Length));
}