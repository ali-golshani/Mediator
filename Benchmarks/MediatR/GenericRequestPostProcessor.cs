using MediatR.Pipeline;

namespace MediatR;

internal class GenericRequestPostProcessor<TRequest, TResponse>(TextWriter writer) : IRequestPostProcessor<TRequest, TResponse>
    where TRequest : notnull
{
    public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
        return writer.WriteLineAsync("- All Done");
    }
}