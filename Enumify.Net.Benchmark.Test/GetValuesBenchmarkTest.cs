using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Enumify.Net.Benchmark.Test
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class GetValuesBenchmarkTest
    {
        [Benchmark]
        public void SystemEnum()
        {
            var values = Enum.GetValues(typeof(DayOfWeek)) as DayOfWeek[];
        }

        [Benchmark]
        public void EnumifyDotNet()
        {
            var values = Enums.GetValues<DayOfWeek>();
        }
    }
}
