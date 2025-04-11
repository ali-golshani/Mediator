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
        await Run_A(mediator);

        WriteLine();

        await Run_B(mediator);

        WriteLine();

        await Run_SA(mediator);

        WriteLine();

        await Run_SB(mediator);

        static void WriteLine()
        {
            string line = new('-', 50);
            Console.WriteLine(line);
        }
    }

    private static async Task Run_A(IMediator mediator)
    {
        Console.WriteLine("RequestA");
        var response = await mediator.Send(new Requests.RequestA.Request(), default);
        Console.WriteLine(response);
    }

    private static async Task Run_B(IMediator mediator)
    {
        Console.WriteLine("RequestB");
        var response = await mediator.Send(new Requests.RequestB.Request
        {
            Number = 1020
        }, default);
        Console.WriteLine(response);
    }

    private static async Task Run_SA(IMediator mediator)
    {
        Console.WriteLine("SpecialRequestA");
        var response = await mediator.Send(new Requests.SpecialRequestA.Request(), default);
        Console.WriteLine(response);
    }

    private static async Task Run_SB(IMediator mediator)
    {
        Console.WriteLine("SpecialRequestB");
        var response = await mediator.Send(new Requests.SpecialRequestB.Request(), default);
        Console.WriteLine(response);
    }
}
