namespace Mediator;

internal class GenericRequestPostProcessor<TRequest, TResponse>(TextWriter writer) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IMessage
{
    public async ValueTask<TResponse> Handle(TRequest message, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        var response = await next(message, cancellationToken);
        await writer.WriteLineAsync("- All Done");
        return response;
    }
}