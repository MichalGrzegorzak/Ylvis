using System.Collections.Generic;
using System.Xml.Linq;

namespace Aegon.Page
{
    public class RssFeedPage : BasePage
    {
        public class ChannelItem
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Description { get; set; }
            public string PubDate { get; set; }
            public string EndDate { get; set; }
            public string Location { get; set; }
            public string Guid { get; set; }

            public static ChannelItem FromXElement(XElement element)
            {
                return new ChannelItem
                {
                    Title = GetElementValue(element, "title"),
                    Link = GetElementValue(element, "link"),
                    Description = GetElementValue(element, "description"),
                    PubDate = GetElementValue(element, "pubDate"),
                    EndDate = GetElementValue(element, "endDate"),
                    Location = GetElementValue(element, "location"),
                    Guid = GetElementValue(element, "guid")
                };
            }
        }

        private XDocument _rssDocument;
        private XDocument RssDocument
        {
            get
            {
                if (_rssDocument != null)
                {
                    return _rssDocument;
                }

                try
                {
                    return _rssDocument = XDocument.Parse(RawPageSource);
                }
                catch
                {
                    return null;
                }
            }
        }

        public XElement RssChannelElement
        {
            get
            {
                return (RssDocument != null && RssDocument.Root != null) ? RssDocument.Root.Element("channel") : null;
            }
        }

        public bool IsValidRssDocument
        {
            get { return RssChannelElement != null; }
        }

        public string ChannelTitle
        {
            get { return GetElementValue("title"); }
        }

        public string ChannelLink
        {
            get { return GetElementValue("link"); }
        }

        public string ChannelDescription
        {
            get { return GetElementValue("description"); }
        }

        public string ChannelPubDate
        {
            get { return GetElementValue("pubDate"); }
        }

        public IEnumerable<ChannelItem> ChannelItems
        {
            get
            {
                foreach (var xmlItem in RssChannelElement.Elements("item"))
                {
                    yield return ChannelItem.FromXElement(xmlItem);
                }
            }
        }

        private static string GetElementValue(XElement root, string name)
        {
            if (root == null)
            {
                return null;
            }

            var element = root.Element(name);
            return element != null ? element.Value : null;
        }

        private string GetElementValue(string name)
        {
            return GetElementValue(RssChannelElement, name);
        }
    }
}
