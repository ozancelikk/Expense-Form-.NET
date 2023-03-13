using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_TimeStampConfigDal : MongoDB_RepositoryBase<TimeStampConfig, MongoDB_Context<TimeStampConfig, MongoDB_TimeStampConfigCollection>>, ITimeStampConfigDal
    {
    }
}
