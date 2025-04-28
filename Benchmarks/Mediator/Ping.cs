namespace Mediator;

public class Ping : IRequest<int>
{
    public required string Message { get; set; }
}

internal class PingHandler : IRequestHandler<Ping, int>
{
    ValueTask<int> IRequestHandler<Ping, int>.Handle(Ping request, CancellationToken cancellationToken) => ValueTask.FromResult(request.Message.Length);
}