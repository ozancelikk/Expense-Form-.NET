using Core.Entities.Concrete;

namespace Core.CrossCuttingConcern.EMail
{
    public interface IMailManager
    {
        void SendMail(MailConfig eMailConfig, EMailContent eMailContent);
    }
}
