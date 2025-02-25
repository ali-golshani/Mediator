namespace Mediator.Sample.Requests.NumbersQuery;

public sealed class Request : IRequest<Request, IReadOnlyCollection<int>>, IRequestA
{ }
