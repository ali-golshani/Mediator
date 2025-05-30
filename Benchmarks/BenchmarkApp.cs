﻿using BenchmarkDotNet.Running;

namespace Benchmarks;

internal static class BenchmarkApp
{
    public static void Run()
    {
        Console.WriteLine("Select Benchmark:");
        Console.WriteLine("1. Send");
        Console.WriteLine("2. Publish");
        Console.WriteLine();
        Console.Write("Select (1|2): ");

        var key = Console.ReadKey();
        Console.WriteLine();

        if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
        {
            BenchmarkRunner.Run<SendBenchmarks>();
        }
        else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
        {
            BenchmarkRunner.Run<PublishBenchmarks>();
        }
    }
}
