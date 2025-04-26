# Minimal Mediator with Custom Pipelines

This mediator enables the definition of different pipelines for various request types, allowing for greater flexibility and control.

### NuGet Package

   ```
   dotnet add package Minimal.Mediator
   ```
## Usage

### **Define a marker interface or base class for each pipeline requests**

   ```csharp
   public interface IRequestA { }
   ```
   
### Define requests and request handlers


```csharp
public sealed class Ping : IRequest<Ping, string>, IRequestA
{
    // Implementation details
}

public sealed class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        // ...
    }
}
```

The `TRequest` generic parameter in the `IRequest` interface is designed to eliminate the need for **C# Reflection** in the implementation of the `Mediator` class. This approach ensures **type safety** and significantly reduces the runtime overhead commonly associated with reflection-based solutions.

### Define middlewares

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

### Define pipelines

   Define Pipelines by using the `KeyedPipeline` Base Class.
   
   This approach involves defining a uniquely named pipeline class along with a configuration class that implements the `IKeyedPipelineConfiguration` interface.

   ```csharp
   internal sealed class PipelineA<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
       where TRequest : IRequest<TRequest, TResponse>, IRequestA
   {
       public PipelineA(IServiceProvider serviceProvider)
           : base(serviceProvider, PipelineAConfiguration.PipelineName)
       { }
   }

   internal sealed class PipelineAConfiguration : IKeyedPipelineConfiguration
   {
       public static string PipelineName { get; } = "Pipeline_A";

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

### Register in DI

   ```csharp
   /// Register Mediator
   services.AddMediator();
   
   ///Register Request-Handlers
   services.AddRequestHandlers(assembly);
   
   ///Register Notification-Handlers
   services.AddNotificationHandlers(assembly);

   ///Register Pipeline
   services.AddKeyedPipeline<PipelineAConfiguration>(typeof(PipelineA<,>));
   ```
### Use IMediator to handle requests

```csharp
private static async Task Sample(IMediator mediator, CancellationToken cancellationToken)
{
    var request = new Ping() { /* ... */ };
    var response = await mediator.Send(request, cancellationToken);
    // ...
}
```

Please refer to the [sample project](Mediator.Sample) for more details.

