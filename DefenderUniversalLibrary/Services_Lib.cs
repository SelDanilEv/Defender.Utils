using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DefenderUniversalLibrary
{
    public class Services_Lib
    {
        public static async Task SendEmail(string emailFrom, string emailPassword, string emailTo, string title, string displayName, string htmlBody = "")
        {
            MailAddress from = new MailAddress(emailFrom, displayName);
            MailAddress to = new MailAddress(emailTo);
            MailMessage message = new MailMessage(from, to)
            {
                Subject = title,
                Body = htmlBody,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(emailFrom, emailPassword),
                EnableSsl = true,
            };

            await smtp.SendMailAsync(message);
        }
    }
}
