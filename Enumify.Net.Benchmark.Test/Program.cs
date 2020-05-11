using System;
using BenchmarkDotNet.Running;

namespace Enumify.Net.Benchmark.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ParseStringToEnumTest>();

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }
    }
}
