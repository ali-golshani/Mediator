namespace Mediator.Exceptions;

public class MultipleRequestPipelinesHaveBeenRegisteredException<TRequest> : MediatorException
{
    public MultipleRequestPipelinesHaveBeenRegisteredException(Type[] pipelineTypes)
        : base(ExceptionMessage(typeof(TRequest)))
    {
        Data["Pipelines"] = pipelineTypes;
    }

    private static string ExceptionMessage(Type requestType)
    {
        return $"Multiple Pipelines for '{requestType}' have been registered.";
    }
}
