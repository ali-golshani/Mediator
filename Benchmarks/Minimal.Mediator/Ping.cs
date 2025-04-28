namespace Minimal.Mediator;

internal class Ping : IRequest<Ping, int>
{
    public required string Message { get; set; }
}

internal class PingHandler : IRequestHandler<Ping, int>
{
    public Task<int> Handle(Ping request, CancellationToken cancellationToken) => Task.FromResult(request.Message.Length);
}
