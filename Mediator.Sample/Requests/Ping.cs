namespace Minimal.Mediator.Sample.Requests;

public sealed class Ping : IRequest<Ping, Pong>, IRequestA
{ }

public sealed class Pong(string message)
{
    public string Message { get; } = message;

    public override string ToString() => Message;
}

internal sealed class PingHandler : IRequestHandler<Ping, Pong>
{
    public Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Pong("Ping Handler"));
    }
}
