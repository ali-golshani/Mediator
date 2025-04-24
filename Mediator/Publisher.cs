namespace Minimal.Mediator;

internal sealed class Publisher<TNotification>(IEnumerable<INotificationHandler<TNotification>> handlers)
    where TNotification : INotification
{
    private readonly INotificationHandler<TNotification>[] handlers = [.. handlers];

    public async Task Publish(TNotification notification, CancellationToken cancellationToken)
    {
        foreach (var handler in handlers)
        {
            await handler.Handle(notification, cancellationToken);
        }
    }
}