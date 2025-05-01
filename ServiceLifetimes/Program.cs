using Microsoft.Extensions.DependencyInjection;

namespace ServiceLifetimes;

internal static class Program
{
    public const int N = 2;
    public const int M = 2;

    static void Main()
    {
        var services = ServiceCollectionBuilder.Build();
        var rootServiceProvider = services.BuildServiceProvider();

        WriteTitle("MediatR");
        MediatR.App.Run(rootServiceProvider);

        WriteTitle("Mediator");
        Mediator.App.Run(rootServiceProvider);

        WriteTitle("Minimal");
        Minimal.Mediator.App.Run(rootServiceProvider);

        Console.WriteLine();
        Console.Write("Press Enter to Exit .");
        Console.ReadLine();
    }

    private static void WriteTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('*', 50));
        Console.WriteLine(title);
        Console.WriteLine();
    }
}
