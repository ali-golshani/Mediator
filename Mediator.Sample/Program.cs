using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Sample;

internal static class Program
{
    static async Task Main()
    {
        var services = ServiceCollectionBuilder.Build();

        var rootServiceProvider = services.BuildServiceProvider();

        using var scope = rootServiceProvider.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        await Run_A(serviceProvider);
        Console.WriteLine("______________________");
        await Run_B(serviceProvider);
        Console.WriteLine("______________________");
        await Run_SB(serviceProvider);
        Console.WriteLine("______________________");

        Console.WriteLine();
        Console.WriteLine("Press Enter to Exit.");
        Console.ReadLine();
    }

    private static async Task Run_A(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var response = await mediator.Send(new Requests.RequestA.Request(), default);
        Console.WriteLine(response);
    }

    private static async Task Run_B(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var response = await mediator.Send(new Requests.RequestB.Request
        {
            Number = 1020
        }, default);
        Console.WriteLine(response);
    }

    private static async Task Run_SB(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var response = await mediator.Send(new Requests.SpecialRequestB.Request(), default);
        Console.WriteLine(response);
    }
}
