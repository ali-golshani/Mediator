namespace Minimal.Mediator;

public sealed class Pong(int value)
{
    public int Value { get; } = value;
}

internal class Ping : IRequest<Ping, Pong>
{
    public required string Message { get; set; }
}

internal class PingHandler : IRequestHandler<Ping, Pong>
{
    public Task<Pong> Handle(Ping request, CancellationToken cancellationToken) => Task.FromResult(new Pong(request.Message.Length));
}
