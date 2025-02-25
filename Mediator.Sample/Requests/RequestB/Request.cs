namespace Mediator.Sample.Requests.RequestB;

public sealed class Request : IRequest<Request, string>, IRequestB
{
    public required int Number { get; init; }
}
