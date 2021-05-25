using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCode
{
    public class SamplesToTest
    {
        public List<string> GetCommonSites(string siteHierarchy)
        {
            string[] sites = siteHierarchy.Split("/").Select(s => s.Trim()).ToArray();

            List<string> commonSites = sites.Intersect<string>(Constants.CUSTOMER_LIST, StringComparer.OrdinalIgnoreCase).ToList<string>();

            return commonSites;
        }

        public string GetFirstCommonSite_Span(string siteHierarchy)
        {
            ReadOnlySpan<string> span = siteHierarchy.Split("/");
            
            for(byte b = 0; b < span.Length; b++)
            {
                if (Constants.CUSTOMER_LIST.Contains(span[b].Trim().ToUpper()))
                {
                    return span[b];
                }
            }

            return string.Empty;
        }

        public string GetFirstCommonSite_WithContains(string siteHierarchy)
        {
            for(byte b = 0; b < Constants.CUSTOMER_LIST.Count; b++)
            {
                if (siteHierarchy.Contains(Constants.CUSTOMER_LIST[b], StringComparison.OrdinalIgnoreCase))
                    return Constants.CUSTOMER_LIST[b];
            }
            return string.Empty;
        }
    }
}
