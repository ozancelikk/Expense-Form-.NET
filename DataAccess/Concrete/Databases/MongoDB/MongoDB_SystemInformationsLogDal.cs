using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_SystemInformationsLogDal : MongoDB_RepositoryBase<SystemInformationsLog, MongoDB_Context<SystemInformationsLog, MongoDB_SystemInformationsLogCollection>>, ISystemInformationsLogDal
    {
        public List<SystemInformationsLog> GetAllSystemInformationLogs()
        {

            using (var operationClaims = new MongoDB_Context<SystemInformationsLog, MongoDB_SystemInformationsLogCollection>())
            {
                operationClaims.GetMongoDBCollection();

              return operationClaims.collection.Find<SystemInformationsLog>(document => true).Limit(1000).Sort("{_id:-1 }").ToList();

            }
        }

        public ICollection<SystemInformationsLog> GetAllUnReadMessageWithPage(int page, int limit)
        {
            using (var context = new MongoDB_Context<SystemInformationsLog, MongoDB_SystemInformationsLogCollection>())
            {
                var builderResult = Builders<SystemInformationsLog>.Filter.Where(x => x.Status == false);
                var result = context.collection.Aggregate().Match(builderResult).Skip(page*limit).Limit(limit).ToList();
                return result;
            }
        }
    }
}
