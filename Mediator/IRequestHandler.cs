namespace Minimal.Mediator;

public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
