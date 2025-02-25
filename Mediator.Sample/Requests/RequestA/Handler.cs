namespace Mediator.Sample.Requests.RequestA;

public sealed class Handler : IRequestHandler<Request, string>
{
    public Task<string> Handle(Request request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Request A");
    }
}
