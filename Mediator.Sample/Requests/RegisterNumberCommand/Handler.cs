namespace Mediator.Sample.Requests.RegisterNumberCommand;

public sealed class Handler : IRequestHandler<Request, Empty>
{
    public Task<Empty> Handle(Request request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Register Number {request.Number}");
        return Empty.Task;
    }
}
