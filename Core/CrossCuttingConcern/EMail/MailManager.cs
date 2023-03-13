using Core.Entities.Concrete;
using System.Net;
using System.Net.Mail;

namespace Core.CrossCuttingConcern.EMail
{
    public class MailManager : IMailManager
    {

        public void SendMail(MailConfig eMailConfig, EMailContent eMailContent)
        {

        
            SmtpClient client = new SmtpClient(eMailConfig.SmtpServer)
            {
                Port = eMailConfig.Port,
                Credentials = new NetworkCredential(eMailConfig.From,eMailConfig.Password),
                EnableSsl = eMailConfig.EnableSsl,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(eMailConfig.From),
                Subject = eMailContent.Subject,
                Body = eMailContent.Body,
                IsBodyHtml = eMailContent.IsBodyHtml,
            };
            foreach (var to in eMailConfig.To)
            {
                mailMessage.To.Add(to);
            }
           

            client.Send(mailMessage);

            mailMessage.Dispose();
        }


    }


}
