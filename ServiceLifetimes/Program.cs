using Microsoft.Extensions.DependencyInjection;

namespace ServiceLifetimes;

internal static class Program
{
    const int N = 2;
    const int M = 2;

    static void Main()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();


        //WriteTitle("Mediator");
        //Mediator(rootServiceProvider);

        //WriteTitle("Minimal");
        //Minimal(rootServiceProvider);

        WriteTitle("MediatR");
        MediatR(rootServiceProvider);

        Console.WriteLine();
        Console.Write("Press Enter to Exit .");
        Console.ReadLine();
    }

    private static void Mediator(ServiceProvider rootServiceProvider)
    {
        for (int i = 0; i < N; i++)
        {
            using var scope = rootServiceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<Mediator.IMediator>();

            for (int j = 0; j < M; j++)
            {
                var ping = new Ping();
                mediator.Send(ping);
            }

            Console.WriteLine();
        }
    }

    private static void Minimal(ServiceProvider rootServiceProvider)
    {
        for (int i = 0; i < N; i++)
        {
            using var scope = rootServiceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<Minimal.Mediator.IMediator>();

            for (int j = 0; j < M; j++)
            {
                var ping = new Ping();
                mediator.Send(ping);
            }

            Console.WriteLine();
        }
    }

    private static void MediatR(ServiceProvider rootServiceProvider)
    {
        for (int i = 0; i < N; i++)
        {
            using var scope = rootServiceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

            for (int j = 0; j < M; j++)
            {
                var ping = new Ping();
                mediator.Send(ping);
            }

            Console.WriteLine();
        }
    }

    private static void WriteTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('*', 50));
        Console.WriteLine(title);
        Console.WriteLine();
    }
}
