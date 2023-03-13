using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.MailServices
{
    public interface IMailOperation
    {
        void SendMail(string subject, string body, bool isBodyHtml);
        void SendMailToCustomAddress(List<string> emails, string subject, string body, bool isBodyHtml);
    }
}
