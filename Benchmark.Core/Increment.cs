using BenchmarkDotNet.Attributes;
using System.Threading;

namespace Benchmark.Core
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50, targetCount: 10, invocationCount: 10, id: "IncrementJob")]
    [MinColumn, Q1Column, MedianColumn, Q3Column, MaxColumn]
    [MarkdownExporter]
    public class Increment
    {
        private int _counter = 0;
        private readonly object _lock = new object();

        [Benchmark]
        public int ThreadUnsafeIncrement() => ++_counter;

        [Benchmark]
        public int InterlockedIncrement() => Interlocked.Increment(ref _counter); 

        [Benchmark]
        public int LockedIncrement()
        {
            lock (_lock)
            {
                ++_counter;
            }

            return _counter;
        }
    }
}
