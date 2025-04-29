namespace Mediator;

public sealed class PingedTwo : INotification { }

internal sealed class PingedTwoHandler1 : INotificationHandler<PingedTwo>
{
    public ValueTask Handle(PingedTwo notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}

internal sealed class PingedTwoHandler2 : INotificationHandler<PingedTwo>
{
    public ValueTask Handle(PingedTwo notification, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}
