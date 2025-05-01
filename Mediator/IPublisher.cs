namespace Minimal.Mediator;

public interface IPublisher<in TNotification>
    where TNotification : INotification
{
    Task Publish(TNotification notification, CancellationToken cancellationToken);
}