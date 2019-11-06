using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;

namespace HungryCake.API.Helpers
{
    public static class RssHelper
    {
        public static async Task<IEnumerable<NewsItem>> GetNewsFeed(string feedUri)
        {
            var rssNewsItems = new List<NewsItem>();

            try
            {
                await ReadSyndication(feedUri, rssNewsItems);
            }
            catch (Exception e)
            {
                if (e is WebException || e is System.Xml.XmlException)
                {
                    await ReadBrokenXml(feedUri, rssNewsItems);
                    Console.WriteLine("WebException error: " + e);
                }
            }

            return rssNewsItems.OrderByDescending(p => p.Posted).ToArray();
        }

        private static async Task ReadSyndication(string feedUri, List<NewsItem> rssNewsItems)
        {
            using (var xmlReader = XmlReader.Create(feedUri, new XmlReaderSettings() { Async = true }))
            {
                var feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == Microsoft.SyndicationFeed.SyndicationElementType.Item)
                    {
                        ISyndicationItem item = await feedReader.ReadItem();
                        rssNewsItems.Add(item.ConvertToNewsItem());
                    }
                }
            }
        }

        private static void ReadXML(string feedUri, List<NewsItem> rssNewsItems)
        {
            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load(feedUri);

            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";
                
                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string posted = rssSubNode != null ? rssSubNode.InnerText : "";

                var item = new NewsItem(title, description, Convert.ToDateTime(posted), link);

                rssNewsItems.Add(item);
            }
        }

        private static async Task ReadBrokenXml(string feedUri, List<NewsItem> rssNewsItems) 
        {
            var source = await HtmlHelper.ReadHtml(feedUri);

            var titlePattern = "<item>.*?<title>(.*?)</title>";
            var matchesTitle = Regex.Matches(source, titlePattern, RegexOptions.Singleline);

            var linkPattern = "<item>.*?<link>(.*?)</link>";
            var matchesLink = Regex.Matches(source, linkPattern, RegexOptions.Singleline);

            var descPattern = "<item>.*?<description>(.*?)</description>";
            var matchesDesc = Regex.Matches(source, descPattern, RegexOptions.Singleline);

            var postedPattern = "<item>.*?<pubDate>(.*?)</pubDate>";
            var matchesPosted = Regex.Matches(source, postedPattern, RegexOptions.Singleline);

            for (int i = 0; i < matchesTitle.Count; i++) 
            {
                var title = matchesTitle[i].Groups[1].Value;
                var link = matchesLink[i].Groups[1].Value;
                var description = matchesDesc[i].Groups[1].Value;
                var posted = matchesPosted[i].Groups[1].Value;

                var item = new NewsItem(title, description, Convert.ToDateTime(posted), link);
                rssNewsItems.Add(item);
            }
        }
    }

    public class NewsItem
    {
        public NewsItem(string title, string content, DateTime posted, string link)
        {
            Title = title;
            Content = Regex.Replace(content, "<.*?>", String.Empty);
            Posted = posted;
            Link = link;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        public string Link { get; set; }
    }

    public static class SyndicationExtensions
    {
        public static NewsItem ConvertToNewsItem(this ISyndicationItem item)
        {
            return new NewsItem(title: item.Title,
                content: item.Description,
                posted: item.Published.UtcDateTime,
                link: item.Links.First().Uri.AbsoluteUri);
        }
    }
}