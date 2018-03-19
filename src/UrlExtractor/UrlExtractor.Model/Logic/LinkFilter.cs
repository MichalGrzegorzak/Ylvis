using System;
using System.Collections.Generic;

namespace UrlExtractor.Model
{
    public class LinkFilter
    {
        public bool FilterLocal { get; set; } = true;
        public bool OnlyOnion { get; set; } = true;

        public LinkGrouper FilterLinks(IEnumerable<string> allLinks)
        {
            LinkGrouper grouper = new LinkGrouper();
            foreach (string link in allLinks)
            {
                if (FilterLocal)
                {
                    if(!link.StartsWith("http"))
                        continue;
                }
                if (OnlyOnion)
                {
                    if (!link.Contains(".onion"))
                        continue;
                }
                grouper.AddLink(link);

            }
            return grouper;
        }
    }
}