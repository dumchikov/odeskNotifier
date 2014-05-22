using System.Collections.Specialized;
using System.Configuration;

namespace ConsoleApplication3.Settimgs
{
    public class OdeskSettings
    {
        private readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;

        public string RssUrl
        {
            get
            {
                return this._appSettings["rssUrl"];
            }
        }
    }
}
