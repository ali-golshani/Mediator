namespace Mediator;

internal class GenericPipelineBehavior<TRequest, TResponse>(TextWriter writer) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IMessage
{
    public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        await writer.WriteLineAsync("-- Handling Request");
        var response = await next(message, cancellationToken);
        await writer.WriteLineAsync("-- Finished Request");
        return response;
    }
}