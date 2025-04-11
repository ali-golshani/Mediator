namespace Mediator.Benchmarks.Requests;

public class Pinged : INotification { }

public class PingedHandler : INotificationHandler<Pinged>
{
    public Task Handle(Pinged notification, CancellationToken cancellationToken) => Task.CompletedTask;
}
