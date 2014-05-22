using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using ConsoleApplication3.Entities;
using ConsoleApplication3.Settimgs;

namespace OdeskNotifier.Services
{
    public class OdeskRssReader
    {
        private readonly OdeskSettings _settings = new OdeskSettings();

        public IList<OdeskJobItem> GetData()
        {
            var reader = XmlReader.Create(this._settings.RssUrl);
            var feed = SyndicationFeed.Load(reader);

            if (feed != null)
            {
                var feedItems = feed.Items;
                var odeskJobItems = 
                    feedItems
                    .Select(x => new OdeskJobItem
                    {
                        Title = x.Title.Text,
                        Link = x.Links[0].Uri.AbsoluteUri,
                        PublishDate = GetPublishDate(x.PublishDate.DateTime)
                    });
                
                return odeskJobItems.ToList();
            }

            throw new Exception("No odesk feed!");
        }

        private static string GetPublishDate(DateTime publishDate)
        {
            var agoTime = DateTime.UtcNow.Subtract(publishDate);
            string text;

            if (agoTime.Days != 0)
            {
                text = string.Format("{0} days", agoTime.Days);
            }
            else
            {
                if (agoTime.Hours != 0)
                {
                    text = string.Format("{0} hours", agoTime.Hours);
                }
                else
                {
                    text = agoTime.Minutes!= 0 ? string.Format("{0} minutes", agoTime.Minutes) : string.Format("{0} seconds", agoTime.Seconds);
                }
            }
            
            return string.Format("{0} - {1} ago", publishDate.ToString("dd/MM/yyyy HH:mm"), text);
        }
    }
}
