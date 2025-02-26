namespace Mediator.Exceptions;

public class MultipleRequestPipelinesAreRegisteredException<TRequest> : MediatorException
{
    public MultipleRequestPipelinesAreRegisteredException(Type[] pipelineTypes)
        : base(ExceptionMessage(typeof(TRequest)))
    {
        Data["Pipeline-Types"] = pipelineTypes;
    }

    private static string ExceptionMessage(Type requestType)
    {
        return $"Multiple Pipelines of '{requestType}' is Registered.";
    }
}
