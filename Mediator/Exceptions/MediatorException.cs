namespace Mediator.Exceptions;

public abstract class MediatorException : Exception
{
    private protected MediatorException() { }
    private protected MediatorException(string? message) : base(message) { }
    private protected MediatorException(string? message, Exception? innerException) : base(message, innerException) { }
}
