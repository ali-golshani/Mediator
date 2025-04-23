namespace Minimal.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
        where TRequest : IRequest<TRequest, TResponse>;

    Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken)
        where TNotification : INotification;
}