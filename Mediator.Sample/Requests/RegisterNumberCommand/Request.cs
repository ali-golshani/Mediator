namespace Mediator.Sample.Requests.RegisterNumberCommand;

public sealed class Request : IRequest<Request, Empty>, IRequestB
{
    public required int Number { get; init; }
}
