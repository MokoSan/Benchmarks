using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark.Core
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net50, targetCount: 10, invocationCount: 10, id: "StringInterpolation")]
    [MinColumn, Q1Column, MedianColumn, Q3Column, MaxColumn]
    [MarkdownExporter, RPlotExporter]
    public class StringInterpolation
    {
        [Benchmark]
        public string RegularInterpolation()
        {
            string someString = "Some string.";
            string interpolate = $"{someString} is a string and is a large string.";
            return interpolate;
        }

        [Benchmark]
        public string RegularInterpolationWithBoxing()
        {
            int num = 500;
            string someString = "Some string.";
            string interpolate = $"{someString} is a string and is a large string but {num} is a number.";
            return interpolate;
        }
    }
}
