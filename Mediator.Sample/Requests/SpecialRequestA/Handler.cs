namespace Mediator.Sample.Requests.SpecialRequestA;

public sealed class Handler : IRequestHandler<Request, string>
{
    public Task<string> Handle(Request request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Special Request A");
    }
}
