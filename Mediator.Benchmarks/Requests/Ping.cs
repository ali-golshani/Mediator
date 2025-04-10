﻿namespace Mediator.Benchmarks.Requests;

public class Ping : IRequest<Ping, int>
{
    public required string Message { get; set; }
}

public class PingHandler : IRequestHandler<Ping, int>
{
    public Task<int> Handle(Ping request, CancellationToken cancellationToken) => Task.FromResult(0);
}
