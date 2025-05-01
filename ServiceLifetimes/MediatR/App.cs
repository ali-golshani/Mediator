using Microsoft.Extensions.DependencyInjection;
using ServiceLifetimes;

namespace MediatR;

public static class App
{
    public const int N = Program.N;
    public const int M = Program.M;

    public static void Run(ServiceProvider rootServiceProvider)
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
}