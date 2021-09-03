using BenchmarkDotNet.Attributes;
using SampleCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Runner
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class FileReadBenchmark
    {
        private static FileRead fr = new FileRead();
        private static string fPath = @"C:\Users\H137345\Downloads\HealthApp.tar\HealthApp\HealthApp.log";
        //[Benchmark(Baseline = true)]
        //public void FileReadUsingStreamReader_WithContains()
        //{
        //    fr.FileReadUsingStreamReader_WithContains(fPath);
        //}

        //[Benchmark]
        //public void FileReadUsingStreamReader_WithIndexOf()
        //{
        //    fr.FileReadUsingStreamReader_WithIndexOf(fPath);
        //}

        //[Benchmark(Baseline = true)]
        //public void FileReadUsingStreamReader_JustRead()
        //{
        //    fr.FileReadUsingStreamReader_JustRead(fPath);
        //}

        //[Benchmark]
        //public void FileReadUsingReadAllText_JustRead()
        //{
        //    fr.FileReadUsingReadAllText_JustRead(fPath);
        //}

        //[benchmark]
        //public void filereadusingreadlines_justread()
        //{
        //    fr.filereadusingreadlines_justread(fpath);
        //}

        [Benchmark]
        public void FileReadUsingBufferedStream_JustRead()
        {
            fr.FileReadUsingBufferedStream_JustRead(fPath);
        }

        //[Benchmark]
        //public void FileReadUsingStreamReader_WithContains_WithoutSplit()
        //{
        //    fr.FileReadUsingStreamReader_WithContains_WithoutSplit(fPath);
        //}
    }
}
