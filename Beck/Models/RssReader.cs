using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

namespace Beck.Models
{
    public class RssReader
    {
        private static XmlReader rssReader;
        private static SyndicationFeed newsFeed;
        public static List<SyndicationItem> GetNews(string url, int take)
        {
            rssReader = XmlReader.Create(url);
            newsFeed = SyndicationFeed.Load(rssReader);
            return (newsFeed.Items.OrderByDescending(i => i.PublishDate).Take(take).ToList());
        }

        public static List<SyndicationItem> GetNews(string url)
        {
            rssReader = XmlReader.Create(url);
            newsFeed = SyndicationFeed.Load(rssReader);
            return (newsFeed.Items.OrderByDescending(i => i.PublishDate).ToList());
        }
    }
}