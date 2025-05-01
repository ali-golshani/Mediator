using Microsoft.Extensions.DependencyInjection;
using ServiceLifetimes;

namespace Mediator;

public static class App
{
    public const int N = Program.N;
    public const int M = Program.M;

    public static void Run(ServiceProvider rootServiceProvider)
    {
        Console.WriteLine($"{nameof(Registry.Lifetime)}: {Registry.Lifetime}");
        Console.WriteLine($"{nameof(Registry.MiddlewareLifetime)}: {Registry.MiddlewareLifetime}");
        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            using var scope = rootServiceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            for (int j = 0; j < M; j++)
            {
                var ping = new Ping();
                mediator.Send(ping);
            }

            Console.WriteLine();
        }
    }
}