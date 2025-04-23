namespace Minimal.Mediator.Sample.Requests;

public sealed class SpecialRequestB : IRequest<SpecialRequestB, string>, IRequestB, ISpecialRequest
{ }

internal sealed class SpecialRequestBHandler : IRequestHandler<SpecialRequestB, string>
{
    public Task<string> Handle(SpecialRequestB request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Special Request B");
    }
}
