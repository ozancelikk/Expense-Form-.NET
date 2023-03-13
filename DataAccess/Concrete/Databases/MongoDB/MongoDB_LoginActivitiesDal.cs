using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_LoginActivitiesDal : MongoDB_RepositoryBase<LoginActivities, MongoDB_Context<LoginActivities, MongoDB_LoginActivitiesCollection>>, ILoginActivitiesDal
    {

    }
}
