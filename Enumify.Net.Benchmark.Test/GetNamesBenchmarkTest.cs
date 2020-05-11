using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Enumify.Net.Benchmark.Test
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class GetNamesBenchmarkTest
    {
        [Benchmark]
        public void SystemEnum()
        {
            var values = Enum.GetNames(typeof(DayOfWeek));
        }

        [Benchmark]
        public void Enumify()
        {
            var values = Enums.GetNames<DayOfWeek>();
        }
    }
}
