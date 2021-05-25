using System;
using System.Collections.Generic;

namespace SampleCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string siteHeirarchy = " / YRCW / Reddaway / STAGING";
            SamplesToTest test = new SamplesToTest();
            List<string> commonSites = test.GetCommonSites(siteHeirarchy);
            string s = test.GetFirstCommonSite_Span(siteHeirarchy);
            string s1 = test.GetFirstCommonSite_WithContains(siteHeirarchy);
        }
    }
}
