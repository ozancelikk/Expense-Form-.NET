using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_ReportHistoryDal : MongoDB_RepositoryBase<ReportHistory, MongoDB_Context<ReportHistory, MongoDB_ReportHistoryCollection>>, IReportHistoryDal
    {
        public List<ReportHistory> GetAllWithPageDSC(int page, int pageSize)
        {
            using(var context = new  MongoDB_RepositoryBase<ReportHistory, MongoDB_Context<ReportHistory, MongoDB_ReportHistoryCollection>>())
            {
                var sortResult = Builders<ReportHistory>.Sort.Descending(x => x.Id);
                var result = context._collection.Aggregate().Sort(sortResult).Skip(page * pageSize).Limit(pageSize).ToList();
                return result;
            }
        }
    }
}
