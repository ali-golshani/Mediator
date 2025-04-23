using MediatR.Pipeline;

namespace MediatR;

internal class GenericRequestPreProcessor<TRequest>(TextWriter writer) : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        return writer.WriteLineAsync("- Starting Up");
    }
}