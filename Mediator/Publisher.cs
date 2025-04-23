namespace Minimal.Mediator;

internal sealed class Publisher<TNotification>
    where TNotification : INotification
{
    private readonly IEnumerable<INotificationHandler<TNotification>> handlers;

    public Publisher(IEnumerable<INotificationHandler<TNotification>> handlers)
    {
        this.handlers = handlers;
    }

    public async Task Publish(TNotification notification, CancellationToken cancellationToken)
    {
        foreach (var handler in handlers)
        {
            await handler.Handle(notification, cancellationToken);
        }
    }
}