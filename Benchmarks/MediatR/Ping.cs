namespace MediatR;

public class Ping : IRequest<int>
{
    public required string Message { get; set; }
}

public class PingHandler : IRequestHandler<Ping, int>
{
    public Task<int> Handle(Ping request, CancellationToken cancellationToken) => Task.FromResult(0);
}