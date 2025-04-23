namespace Mediator;

public class Pinged : INotification { }

internal class PingedHandler : INotificationHandler<Pinged>
{
    ValueTask INotificationHandler<Pinged>.Handle(Pinged notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}