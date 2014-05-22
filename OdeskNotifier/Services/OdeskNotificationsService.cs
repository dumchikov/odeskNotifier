using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Entities;

namespace OdeskNotifier.Services
{
    public class OdeskNotificationsService
    {
        private readonly OdeskRssReader _odeskRssReader = new OdeskRssReader();

        private readonly MailService _mail = new MailService();

        public static IEnumerable<OdeskJobItem> PreviousJobItems = new List<OdeskJobItem>();

        public void Notify()
        {
            var data = _odeskRssReader.GetData();
            var newJobs = data.Except(PreviousJobItems).ToList();
            if (newJobs.Any())
            {
                _mail.Send("Odesk notification.", newJobs);
                PreviousJobItems = data;
            }
        }
    }
}