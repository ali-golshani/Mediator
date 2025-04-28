namespace Mediator;

public class PingedTwo : INotification { }

internal class PingedTwoHandler1 : INotificationHandler<PingedTwo>
{
    public ValueTask Handle(PingedTwo notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}

internal class PingedTwoHandler2 : INotificationHandler<PingedTwo>
{
    public ValueTask Handle(PingedTwo notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}
