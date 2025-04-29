namespace Mediator;

public sealed class Pinged : INotification { }

internal sealed class PingedHandler : INotificationHandler<Pinged>
{
    public ValueTask Handle(Pinged notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}