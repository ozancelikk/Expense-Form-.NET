using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;

namespace DataAccess.Abstract
{
    public interface IReportDal : IEntityRepository<ScheduledReport>
    {
    }
}
