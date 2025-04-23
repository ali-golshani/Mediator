namespace Minimal.Mediator.Exceptions;

public class UnexpectedRequestTypeException<TRequest> : MediatorException
{
    public UnexpectedRequestTypeException(object request)
        : base(ExceptionMessage(typeof(TRequest), request.GetType()))
    { }

    private static string ExceptionMessage(Type expectedType, Type requestType)
    {
        return $"Unexpected request type encountered: '{requestType}'. Expected type: '{expectedType}'.";
    }
}
