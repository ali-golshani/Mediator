namespace Mediator;

public class Pinged : INotification { }

internal class PingedHandler : INotificationHandler<Pinged>
{
    public ValueTask Handle(Pinged notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}