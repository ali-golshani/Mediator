namespace Mediator;

public interface IMediator
{
    Task<TResponse> Send<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
        where TRequest : IRequest<TRequest, TResponse>;
}
