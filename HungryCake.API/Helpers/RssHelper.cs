using System;
using System.Collections.Generic;
using System.Linq;
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
            return rssNewsItems.OrderByDescending(p => p.PublishDate).ToArray();
        }
    }

    public class NewsItem
    {
        public NewsItem(string title, string excerpt, DateTime publishDate, string uri)
        {
            Title = title;
            Excerpt = Regex.Replace(excerpt, "<.*?>", String.Empty);
            PublishDate = publishDate;
            Uri = uri;
        }

        public string Title { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
        public string Uri { get; set; }
    }

    public static class SyndicationExtensions
    {
        public static NewsItem ConvertToNewsItem(this ISyndicationItem item)
        {
            return new NewsItem(title: item.Title,
                excerpt: item.Description,
                publishDate: item.Published.UtcDateTime,
                uri: item.Links.First().Uri.AbsoluteUri);
        }
    }
}