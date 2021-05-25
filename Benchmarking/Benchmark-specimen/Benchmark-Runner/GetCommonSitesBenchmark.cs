using System;
using System.Collections.Generic;
using System.Text;
using SampleCode;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace Benchmark_Runner
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class GetCommonSitesBenchmark
    {
        private static string siteHeriarcy = " / YRCW / Reddaway / STAGING";
        private static SamplesToTest s = new SamplesToTest();

        [Benchmark(Baseline = true)]
        public void GetCommonSites_Isolated()
        {
            List<string> commonSites = s.GetCommonSites(siteHeriarcy);
        }

        
        public void GetCommonSites_FromMain()
        {
            SampleCode.Program.Main(new string[] { });
        }

        [Benchmark]
        public void GetCommonSite_WithSpan()
        {
            string site = s.GetFirstCommonSite_Span(siteHeriarcy);
        }

        [Benchmark]
        public void GetCommonSite_WithContains()
        {
            string site = s.GetFirstCommonSite_WithContains(siteHeriarcy);
        }
    }
}
