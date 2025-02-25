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
        await Run_B(serviceProvider);

        Console.WriteLine("Press Enter to Exit.");
        Console.ReadLine();
    }

    private static async Task Run_A(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var numbers = await mediator.Send(new Requests.NumbersQuery.Request(), default);
        var text = string.Join(' ', numbers);
        Console.WriteLine(text);
    }

    private static async Task Run_B(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        await mediator.Send(new Requests.RegisterNumberCommand.Request
        {
            Number = 1020
        }, default);
    }
}
