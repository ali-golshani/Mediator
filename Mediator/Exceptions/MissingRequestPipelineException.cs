namespace Minimal.Mediator.Exceptions;

public class MissingRequestPipelineException<TRequest> : MediatorException
{
    public MissingRequestPipelineException()
        : base(ExceptionMessage(typeof(TRequest)))
    { }

    private static string ExceptionMessage(Type requestType)
    {
        return $"The Pipeline for '{requestType}' is not Registered.";
    }
}
