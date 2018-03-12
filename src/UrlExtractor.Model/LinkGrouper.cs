using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlExtractor.Model
{
    public class LinkGrouper
    {
        public int GroupByXletters { get; set; } = 3;
        public Dictionary<string, string[]> Groups { get; set; }

        List<string> allLinks = new List<string>();
        

        public void AddLink(string link)
        {
            allLinks.Add(link);
        }

        public override string ToString() => string.Join("\n", allLinks);

        public void AssignToGroups()
        {
            var splitted = allLinks
                .Take(15)
                .Select(x => x.Replace("https://","").Replace("http://", "") )
                
                 //filtering empty
                .Select(x => x.Split(new []{".onion"}, StringSplitOptions.RemoveEmptyEntries)).Where(x => x.Length > 1).Select(x => string.Join("",x))
                
                .Select(x => new [] {x.Substring(0, GroupByXletters), x.Substring(GroupByXletters)})
                ;

            var lookup = splitted.ToLookup(p => p[0], p => p[1]);
            Groups = lookup.ToDictionary(x => x.Key, x => x.ToArray());
        }
    }
}