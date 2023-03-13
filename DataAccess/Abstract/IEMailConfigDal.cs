using Core.DataAccess.Databases;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public interface IEMailConfigDal: IEntityRepository<MailConfig>
    {
    }
}
