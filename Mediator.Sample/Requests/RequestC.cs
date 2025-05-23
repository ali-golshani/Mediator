namespace Minimal.Mediator.Sample.Requests;

public sealed class RequestC : IRequest<RequestC, string>
{ }

internal sealed class RequestCHandler : IRequestHandler<RequestC, string>
{
    public Task<string> Handle(RequestC request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Request C Handler");
    }
}
