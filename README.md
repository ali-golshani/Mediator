# Mediator with Custom Pipelines

This mediator enables the definition of different pipelines for various request types, allowing for greater flexibility and control.

## Usage

### **Define a Marker Interface or Base Class for Each Pipeline requests**

   ```csharp
   public interface IRequestA { }
   ```
   
## Define Requests and Request Handlers


```csharp
public interface IRequest<in TRequest, out TResponse> { }

public sealed class RequestX : IRequest<RequestX, string>, IRequestA
{
    // Implementation details
}

public sealed class RequestXHandler : IRequestHandler<RequestX, string>
{
    public Task<string> Handle(RequestX request, CancellationToken cancellationToken)
    {
        // ...
    }
}
```

The `TRequest` generic parameter in the `IRequest` interface is designed to eliminate the need for **C# Reflection** in the implementation of the `Mediator` class. This approach ensures **type safety** and significantly reduces the runtime overhead commonly associated with reflection-based solutions.

## Define Middlewares

Custom middleware can be created to process general or specific request types. C#'s generic type constraints (`where` keyword) can be used to enforce type restrictions.

```csharp
public sealed class ExceptionHandlingMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
{
    public async Task<TResponse> Handle(RequestContext<TRequest> context, IRequestProcessor<TRequest, TResponse> next)
    {
        try
        {
            return await next.Handle(context);
        }
        catch (Exception exp)
        {
            // Exception handling logic
        }
    }
}

public sealed class SpecialMiddleware<TRequest, TResponse> : IMiddleware<TRequest, TResponse>
    where TRequest : ISpecialRequest
{
    // Middleware implementation
}
```

## Define Pipelines

   Pipelines can be defined in two ways:

   ### a. Using the `Pipeline` Base Class

   The `Pipeline` base class accepts a request handler (`IRequestHandler`) along with pipeline middlewares (`IMiddleware`) as input parameters.

   ```csharp
   public abstract class Pipeline<TRequest, TResponse> : IPipeline<TRequest, TResponse>
       where TRequest : IRequest<TRequest, TResponse>
   {
       protected Pipeline(
           IRequestHandler<TRequest, TResponse> handler,
           params IMiddleware<TRequest, TResponse>[] middlewares)
       {
           // Base pipeline implementation
       }
   }

   public sealed class PipelineA<TRequest, TResponse> : Pipeline<TRequest, TResponse>
       where TRequest : IRequest<TRequest, TResponse>, IRequestA
   {
       public PipelineA(
           IRequestHandler<TRequest, TResponse> handler,
           ExceptionHandlingMiddleware<TRequest, TResponse> exceptionHandling,
           ValidationMiddleware<TRequest, TResponse> validation)
           : base(handler, exceptionHandling, validation)
       { }
   }
   ```

   Register the pipeline in Dependency Injection (DI):

   ```csharp
   services.AddScoped(typeof(IPipeline<,>), typeof(PipelineA<,>));
   ```

   ### b. Using the `KeyedPipeline` Base Class (Recommended)

   This approach involves defining a uniquely named pipeline class along with a configuration class that implements the `IKeyedPipelineConfiguration` interface.

   ```csharp
   public abstract class KeyedPipeline<TRequest, TResponse> : IPipeline<TRequest, TResponse>
       where TRequest : IRequest<TRequest, TResponse>
   {
       protected KeyedPipeline(IServiceProvider serviceProvider, string pipelineName)
       { 
            // ...
       }

       // Keyed pipeline base class implementation
   }

   internal sealed class PipelineB<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
       where TRequest : IRequest<TRequest, TResponse>, IRequestB
   {
       public PipelineB(IServiceProvider serviceProvider)
           : base(serviceProvider, PipelineBConfiguration.PipelineName)
       { }
   }

   internal sealed class PipelineBConfiguration : IKeyedPipelineConfiguration
   {
       public static string PipelineName { get; } = "Pipeline_B";

       public static Type[] Middlewares()
       {
           return
           [
               typeof(ExceptionHandlingMiddleware<,>),
               typeof(ValidationMiddleware<,>),
               typeof(SpecialMiddleware<,>),
           ];
       }
   }
   ```

   Register the pipeline in DI:

   ```csharp
   services.AddTransient(typeof(IPipeline<,>), typeof(PipelineB<,>));
   services.RegisterMiddlewares<PipelineBConfiguration>();
   ```
## Use IMediator to handle requests

```csharp
private static async Task Sample(IMediator mediator, CancellationToken cancellationToken)
{
    var request = new RequestX() { /* ... */ };
    var response = await mediator.Send(request, cancellationToken);
    // ...
}
```
