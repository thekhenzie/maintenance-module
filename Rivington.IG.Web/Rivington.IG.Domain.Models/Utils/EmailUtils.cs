using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Rivington.IG.Domain.Models.Utils
{
    public static class EmailUtils
    {
        public static void SendEmail(string webHost, string fromEmail, string toEmail, string subject, string emailBody)
        {
            var addressFrom = new MailAddress(fromEmail, "Inspector Gadget");
            var addressTo = new MailAddress(toEmail);
            var message = new MailMessage(addressFrom, addressTo);

            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = emailBody;

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential(fromEmail, "InspectorgadgetRiv"),
                EnableSsl = true
            };
            client.Send(message);
        }
    }
}
