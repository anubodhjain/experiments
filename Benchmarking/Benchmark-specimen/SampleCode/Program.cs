using System;
using System.Collections.Generic;

namespace SampleCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            FileRead();
        }

        static void SamepleToTest()
        {
            string siteHeirarchy = " / YRCW / Reddaway / STAGING";
            SamplesToTest test = new SamplesToTest();
            List<string> commonSites = test.GetCommonSites(siteHeirarchy);
            string s = test.GetFirstCommonSite_Span(siteHeirarchy);
            string s1 = test.GetFirstCommonSite_WithContains(siteHeirarchy);
        }

        static void FileRead()
        {
            FileRead fr = new FileRead();
            fr.FileReadUsingStreamReader_WithContains(@"C:\Users\H137345\Downloads\HealthApp.tar\HealthApp\HealthApp.log");
            fr.FileReadUsingStreamReader_WithIndexOf(@"C:\Users\H137345\Downloads\HealthApp.tar\HealthApp\HealthApp.log");
            fr.FileReadUsingStreamReader_WithContains_WithoutSplit(@"C:\Users\H137345\Downloads\HealthApp.tar\HealthApp\HealthApp.log");
        }
    }
}
