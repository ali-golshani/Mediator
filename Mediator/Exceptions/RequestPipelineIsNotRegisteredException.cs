namespace Mediator.Exceptions;

public class RequestPipelineIsNotRegisteredException<TRequest> : MediatorException
{
    public RequestPipelineIsNotRegisteredException()
        : base(ExceptionMessage(typeof(TRequest)))
    { }

    private static string ExceptionMessage(Type requestType)
    {
        return $"The Pipeline for '{requestType}' is not Registered.";
    }
}
