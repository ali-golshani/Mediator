namespace Mediator.Sample.Requests;

public sealed class SpecialRequestA : IRequest<SpecialRequestA, string>, IRequestA, ISpecialRequest
{ }

public sealed class SpecialRequestAHandler : IRequestHandler<SpecialRequestA, string>
{
    public Task<string> Handle(SpecialRequestA request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Special Request A");
    }
}
