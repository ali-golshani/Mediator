using FluentValidation;

namespace Minimal.Mediator.Sample.Requests;

public sealed class RequestB : IRequest<RequestB, string>, IRequestB
{
    public required int Number { get; init; }
}

internal sealed class RequestBValidator : AbstractValidator<RequestB>
{
    public RequestBValidator()
    {
        RuleFor(x => x.Number).GreaterThan(0);
    }
}

internal sealed class RequestBHandler : IRequestHandler<RequestB, string>
{
    public Task<string> Handle(RequestB request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"Request B  Handler : Request.Number = {request.Number}");
    }
}
