namespace Minimal.Mediator.Sample.Requests;

public sealed class RequestA : IRequest<RequestA, string>, IRequestA
{ }

internal sealed class RequestAHandler : IRequestHandler<RequestA, string>
{
    public Task<string> Handle(RequestA request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Request A Handler");
    }
}
