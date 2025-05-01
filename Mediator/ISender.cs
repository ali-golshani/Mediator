namespace Minimal.Mediator;

public interface ISender<in TRequest, TResponse>
    where TRequest : IRequest<TRequest, TResponse>
{
    Task<TResponse> Send(TRequest request, CancellationToken cancellationToken);
}
