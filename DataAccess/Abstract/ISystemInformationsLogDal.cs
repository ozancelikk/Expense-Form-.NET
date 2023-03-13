using Core.DataAccess.Databases;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ISystemInformationsLogDal : IEntityRepository<SystemInformationsLog>
    {
        List<SystemInformationsLog> GetAllSystemInformationLogs();
        ICollection<SystemInformationsLog> GetAllUnReadMessageWithPage(int page, int limit);
    }
}
