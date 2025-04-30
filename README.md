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
public sealed class Ping : IRequest<Ping, Pong>, IRequestA
{
    // Implementation details
}

public sealed class PingHandler : IRequestHandler<Ping, Pong>
{
    public Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
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

public sealed class PingMiddleware : IMiddleware<Ping, Pong>
{
    // Middleware implementation
}
```

### Define pipelines

   Define Pipelines by using the `KeyedPipeline` Base Class.
   
   This approach involves defining a uniquely named pipeline class along with a configuration class that implements the `IKeyedPipelineConfiguration` interface.

   ```csharp

   internal static class PipelineA
   {
       public sealed class Pipeline<TRequest, TResponse> : KeyedPipeline<TRequest, TResponse>
           where TRequest : IRequest<TRequest, TResponse>, IRequestA
       {
           public Pipeline(IServiceProvider serviceProvider)
               : base(serviceProvider, Configuration.PipelineName)
           { }
       }
   
       public sealed class Configuration : IKeyedPipelineConfiguration
       {
           public static string PipelineName { get; } = "Pipeline_A";
   
           public static MiddlewareDescriptor[] Middlewares()
           {
               return
               [
                   new MiddlewareDescriptor(typeof(ExceptionHandlingMiddleware<,>)),
                   new MiddlewareDescriptor(typeof(ValidationMiddleware<,>)),
                   new MiddlewareDescriptor(typeof(SpecialMiddleware<,>)),
                   new MiddlewareDescriptor(typeof(PingMiddleware), typeof(IMiddleware<Ping, Pong>)),
               ];
           }
       }
   }

   ```

### Register in DI

   ```csharp
   /// Register Mediator
   services.AddMediator();

   ///Register Pipeline
   services.AddKeyedPipeline<PipelineA.Configuration>(typeof(PipelineA.Pipeline<,>));
   ```
   To automatically register Request-Handlers and Notification-Handlers, consider using the [ServiceScan.SourceGenerator](https://github.com/Dreamescaper/ServiceScan.SourceGenerator) package or the [Scrutor](https://github.com/khellang/Scrutor) package if Native AOT is not a concern ([code](Mediator.Sample/Extensions)).
   
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

