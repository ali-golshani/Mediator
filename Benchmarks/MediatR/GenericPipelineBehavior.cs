namespace MediatR;

internal class GenericPipelineBehavior<TRequest, TResponse>(TextWriter writer) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        await writer.WriteLineAsync("-- Handling Request");
        var response = await next(cancellationToken);
        await writer.WriteLineAsync("-- Finished Request");
        return response;
    }
}