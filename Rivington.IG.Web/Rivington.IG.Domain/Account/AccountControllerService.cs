using Rivington.IG.Domain.CustomCodes;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Rivington.IG.Domain.Account
{
    public class AccountControllerService : IAccountcontrollerService
    {
        public AccountControllerService()
        {
        }

        public void SendEmail(string emailSubject, string toEmail, string emailBody, Attachment profilePhoto = null)
        {
            var message = new MailMessage();

            string[] insuredEmails = toEmail.Split(new[] { "," }, StringSplitOptions.None);
            foreach (var insuredEmail in insuredEmails)
            {
                message.To.Add(insuredEmail);
            }
            message.From = new MailAddress(AppSettings.Configuration["EmailSender"], "Inspector Gadget");
            message.IsBodyHtml = true;
            message.Subject = emailSubject;
            message.Body = emailBody.ToString();

            if (profilePhoto != null)
            {
                message.Attachments.Add(profilePhoto);
            }

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential(AppSettings.Configuration["EmailSender"], "InspectorgadgetRiv"),
                EnableSsl = true
            };
            client.Send(message);
        }
    }
}