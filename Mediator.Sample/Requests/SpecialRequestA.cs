namespace Minimal.Mediator.Sample.Requests;

public sealed class SpecialRequestA : IRequest<SpecialRequestA, string>, IRequestA, ISpecialRequest
{ }

internal sealed class SpecialRequestAHandler : IRequestHandler<SpecialRequestA, string>
{
    public Task<string> Handle(SpecialRequestA request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Special Request A Handler");
    }
}
