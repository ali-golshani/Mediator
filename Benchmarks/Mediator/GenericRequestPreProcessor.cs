namespace Mediator;

internal class GenericRequestPreProcessor<TRequest, TResponse>(TextWriter writer) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IMessage
{
    public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        await writer.WriteLineAsync("- Starting Up");
        return await next(message, cancellationToken);
    }
}