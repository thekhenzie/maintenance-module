using System.Net.Mail;

namespace Rivington.IG.Domain.Account
{
    public interface IAccountcontrollerService
    {
        void SendEmail(string emailSubject, string toEmail, string emailBody, Attachment profilePhoto = null);
    }
}