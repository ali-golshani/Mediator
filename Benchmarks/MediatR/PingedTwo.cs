namespace MediatR;

internal class PingedTwo : INotification { }

internal class PingedTwoHandler1 : INotificationHandler<PingedTwo>
{
    public Task Handle(PingedTwo notification, CancellationToken cancellationToken) => Task.CompletedTask;
}

internal class PingedTwoHandler2 : INotificationHandler<PingedTwo>
{
    public Task Handle(PingedTwo notification, CancellationToken cancellationToken) => Task.CompletedTask;
}