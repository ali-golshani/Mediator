using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Minimal.Mediator.Sample;

internal static class Program
{
    [RequiresUnreferencedCode("Calls Minimal.Mediator.Sample.ServiceCollectionBuilder.Build()")]
    static async Task Main()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        using var scope = rootServiceProvider.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        try
        {
            var mediator = serviceProvider.GetRequiredService<IMediator>();
            await Run(mediator);
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp);
        }

        Console.WriteLine();
        Console.Write("Press Enter to Exit ...");
        Console.ReadLine();
    }

    private static async Task Run(IMediator mediator)
    {
        await Send(mediator, new Requests.RequestA());
        await Send(mediator, new Requests.RequestB { Number = 1020 });
        await Send(mediator, new Requests.SpecialRequestA());
        await Send(mediator, new Requests.SpecialRequestB());
        await Send(mediator, new Requests.Ping());
    }

    private static async Task Send<TRequest, TResponse>(IMediator mediator, IRequest<TRequest, TResponse> request)
        where TRequest : IRequest<TRequest, TResponse>
    {
        Console.WriteLine(request.GetType().Name);
        var response = await mediator.Send(request, default);
        Console.WriteLine(response);
        WriteLine();
    }

    private static void WriteLine()
    {
        Console.WriteLine(new string('-', 50));
    }
}
