using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Benchmark.Core
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50, targetCount: 10, invocationCount: 10, id: "ConcurrentDictionaryVsFineGrainLockedDictionaryJob")]
    [MinColumn, Q1Column, MedianColumn, Q3Column, MaxColumn]
    [MarkdownExporter, RPlotExporter]
    public class ConcurrentDictionaryVsFineGrainLockedDictionary
    {
        private readonly Dictionary<string, string> _threadUnsafeDictionary = new Dictionary<string, string>();
        private readonly object _lock = new object();

        private readonly ConcurrentDictionary<string, string> _concurrentDictionary = new ConcurrentDictionary<string, string>();

        [Benchmark]
        public void AddToFineGrainLockedDictionary()
        {
            lock (_lock)
            {
                _threadUnsafeDictionary["1"] = "1";
                _threadUnsafeDictionary["2"] = "2";
                _threadUnsafeDictionary["3"] = "3";
                _threadUnsafeDictionary["4"] = "4";
            }
        }

        [Benchmark]
        public void AddToConcurrentDictionary()
        {
            _concurrentDictionary["1"] = "1";
            _concurrentDictionary["2"] = "2";
            _concurrentDictionary["3"] = "3";
            _concurrentDictionary["4"] = "4";
        }
    }
}
