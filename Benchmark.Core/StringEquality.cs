using BenchmarkDotNet.Attributes;
using System;

namespace Benchmark.Core
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50, targetCount: 10, invocationCount: 10, id: "StringEqualityJob")]
    [MinColumn, Q1Column, MedianColumn, Q3Column, MaxColumn]
    [MarkdownExporter, RPlotExporter]
    [MemoryDiagnoser]
    public class StringEquality
    {
        [Params("FooBarBuzz", "BuzzFooBar")]
        public string Comparer { get; set; }

        [Params("BuzzFooBar1", "BuzzFooBar")]
        public string Comparand{ get; set; }

        [Benchmark]
        public bool IsEqualCompareOrdinal()
            => string.CompareOrdinal(Comparand, Comparer) == 0;

        [Benchmark]
        public bool IsEqualCompare()
            => string.Compare(Comparand, Comparer) == 0;

        [Benchmark]
        public bool IsEqualUsingEquals()
            => string.Equals(Comparer, Comparand); 

        [Benchmark]
        public bool IsEqualUsingEqualsWithOrdinal()
            => string.Equals(Comparer, Comparand, StringComparison.Ordinal); 

        [Benchmark]
        public bool IsEqualUsingEqualsWithOrdinalIgnoreCase()
            => string.Equals(Comparer, Comparand, StringComparison.OrdinalIgnoreCase); 
    }
}
