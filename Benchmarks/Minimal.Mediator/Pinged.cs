namespace Minimal.Mediator;

internal class Pinged : INotification { }

internal class PingedHandler : INotificationHandler<Pinged>
{
    public Task Handle(Pinged notification, CancellationToken cancellationToken) => Task.CompletedTask;
}
