namespace Mediator.Exceptions;

public class MultipleRequestPipelinesAreRegisteredException<TRequest> : MediatorException
{
    public MultipleRequestPipelinesAreRegisteredException(Type[] pipelineTypes)
        : base(ExceptionMessage(typeof(TRequest)))
    {
        Data["Pipelines"] = pipelineTypes;
    }

    private static string ExceptionMessage(Type requestType)
    {
        return $"Multiple Pipelines for '{requestType}' have been registered.";
    }
}
