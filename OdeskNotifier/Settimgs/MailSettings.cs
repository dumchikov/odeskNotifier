using System.Collections.Specialized;
using System.Configuration;

namespace ConsoleApplication3.Settimgs
{
    public class MailSettings
    {
        private readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;

        public string Host
        {
            get
            {
                return this._appSettings["host"];
            }
        }

        public int Port
        {
            get
            {
                return int.Parse(this._appSettings["port"]);
            }
        }

        public string Login
        {
            get
            {
                return this._appSettings["login"];
            }
        }

        public string Password
        {
            get
            {
                return this._appSettings["password"];
            }
        }
    }
}
