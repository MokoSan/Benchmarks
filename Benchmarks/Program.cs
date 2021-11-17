using Benchmark.Core;
using BenchmarkDotNet.Running;
using System;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Increment>();
            BenchmarkRunner.Run<ConcurrentDictionaryVsFineGrainLockedDictionary>();
            BenchmarkRunner.Run<StringEquality>();
            BenchmarkRunner.Run<StringInterpolation>();
            Console.ReadKey();
        }
    }
}