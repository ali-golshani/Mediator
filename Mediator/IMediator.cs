namespace Minimal.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TRequest, TResponse>;

    Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification;
}