namespace Minimal.Mediator.Exceptions;

public class DuplicateRequestPipelineException<TRequest> : MediatorException
{
    public DuplicateRequestPipelineException(Type[] pipelineTypes)
        : base(ExceptionMessage(typeof(TRequest)))
    {
        Data["Pipelines"] = pipelineTypes;
    }

    private static string ExceptionMessage(Type requestType)
    {
        return $"Multiple Pipelines for '{requestType}' have been registered.";
    }
}
