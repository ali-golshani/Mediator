namespace Mediator.Sample.Requests.NumbersQuery;

public sealed class Handler : IRequestHandler<Request, IReadOnlyCollection<int>>
{
    public Task<IReadOnlyCollection<int>> Handle(Request request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<int> result = [1, 3, 5, 7, 9];
        return Task.FromResult(result);
    }
}
