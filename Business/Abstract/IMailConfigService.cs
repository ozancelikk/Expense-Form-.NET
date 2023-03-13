using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IMailConfigService
    {
        IDataResult<MailConfig> GetById(string id);
        IDataResult<List<MailConfig>> GetAll();
        IResult Add(MailConfig eMailConfig);
        IResult Delete(MailConfig eMailConfig);
        IDataResult<MailConfig> Get();
        IDataResult<MailConfig> GetByEmail(string email);
        IResult Update(MailConfig eMailConfig);

    }
}
