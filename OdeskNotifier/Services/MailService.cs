using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ConsoleApplication3.Entities;
using ConsoleApplication3.Settimgs;

namespace OdeskNotifier.Services
{
    public class MailService
    {
        private readonly SmtpClient _smtpClient;

        private readonly MailSettings _settings = new MailSettings();

        public MailService()
        {
            this._smtpClient = new SmtpClient(this._settings.Host, this._settings.Port)
                {
                    Credentials = new NetworkCredential(this._settings.Login, this._settings.Password),
                    EnableSsl = true
                };
        }

        public void Send(string subject, IEnumerable<OdeskJobItem> jobItems)
        {
            var message = new MailMessage(this._settings.Login, this._settings.Login)
                {
                    Body = TableResult(jobItems),
                    IsBodyHtml = true,
                    Subject = subject
                };

            this._smtpClient.Send(message);
        }

        private static string TableResult(IEnumerable<OdeskJobItem> items)
        {
            var builder = new StringBuilder("<table border=\"1\" cellspacing=\"0\" cellpadding=\"5\" style=\"100%\"><tr><th>Date</th><th>Title</th><th>Link</th></tr>");

            foreach (var odeskJobItem in items)
            {
                builder.Append("<tr>");
                builder.AppendFormat("<td>{0}</td>", odeskJobItem.PublishDate);
                builder.AppendFormat("<td>{0}</td>", odeskJobItem.Title);
                builder.AppendFormat("<td><a href=\"{0}\">View</a></td>", odeskJobItem.Link);
                builder.Append("</tr>");
            }

            builder.Append("</table>");
            return builder.ToString();
        }
    }
}
