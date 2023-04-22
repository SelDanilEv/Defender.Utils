using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Defender.Utils
{
    [Obsolete]
    public class EmailUtils
    {
        public async Task SendEmail(
            string emailFrom,
            string emailPassword,
            string emailTo,
            string title,
            string displayName,
            string htmlBody = "")
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
