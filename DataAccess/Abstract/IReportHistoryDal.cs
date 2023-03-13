using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IReportHistoryDal : IEntityRepository<ReportHistory>
    {
      List<ReportHistory> GetAllWithPageDSC(int page, int pageSize);
    }
}
