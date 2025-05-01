namespace Minimal.Mediator;

public interface IPublisher<TNotification>
    where TNotification : INotification
{
    Task Publish(TNotification notification, CancellationToken cancellationToken);
}