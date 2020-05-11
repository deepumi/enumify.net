using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Enumify.Net.Benchmark.Test
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ParseStringToEnumTest
    {
        [Benchmark]
        public void SystemEnum()
        {
            var values = Enum.Parse<DayOfWeek>("Saturday");
        }

        [Benchmark]
        public void Enumify()
        {
            var values = Enums.Parse<DayOfWeek>("Saturday");
        }
    }
}
