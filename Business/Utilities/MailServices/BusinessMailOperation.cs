using Business.Abstract;
using Core.CrossCuttingConcern.EMail;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Utilities.MailServices
{
    public class BusinessMailOperation : IMailOperation
    {
        private IMailManager _eMailManager;
        private IEMailConfigDal _eMailConfigService;
        public BusinessMailOperation(IEMailConfigDal mailConfigService, IMailManager mailManager)
        {

            _eMailConfigService = mailConfigService;
            _eMailManager = mailManager;
        }

        public void SendMail(string subject,string body, bool isBodyHtml)
        {


            var eMailConfigurations = _eMailConfigService.GetAll();
            if (eMailConfigurations != null)
            {
                EMailContent eMailContent = new EMailContent { Subject = subject, Body = body, IsBodyHtml = isBodyHtml };
                foreach (var emailConfiguration in eMailConfigurations)
                {
                    _eMailManager.SendMail(emailConfiguration, eMailContent);
                }

            }
        }

        public void SendMailToCustomAddress(List<string> emails, string subject, string body, bool isBodyHtml)
        {
            var eMailConfiguration = _eMailConfigService.Get();
            eMailConfiguration.To = emails;
            if (eMailConfiguration != null)
            {
                EMailContent eMailContent = new EMailContent { Subject = subject, Body = body, IsBodyHtml = isBodyHtml };
             
                    _eMailManager.SendMail(eMailConfiguration, eMailContent);
                

            }
        }


    }
}
