using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EMailConfigDal : MongoDB_RepositoryBase<MailConfig, MongoDB_Context<MailConfig, MongoDB_EMailConfigCollection>>, IEMailConfigDal
    {
    }
}
