namespace Mediator.Exceptions;

public class RequestPipelineIsNotRegisteredException<TRequest> : MediatorException
{
    public RequestPipelineIsNotRegisteredException()
        : base(ExceptionMessage(typeof(TRequest)))
    { }

    private static string ExceptionMessage(Type requestType)
    {
        return $"Pipeline of '{requestType}' is not Registered.";
    }
}
