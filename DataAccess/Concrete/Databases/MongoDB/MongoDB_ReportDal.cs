using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_ReportDal : MongoDB_RepositoryBase<ScheduledReport, MongoDB_Context<ScheduledReport, MongoDB_ReportCollection>>, IReportDal
    {

    }
}
