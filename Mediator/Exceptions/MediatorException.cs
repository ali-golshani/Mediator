namespace Mediator.Exceptions;

public abstract class MediatorException : Exception
{
    private protected MediatorException(string? message) : base(message) { }
}
