using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISystemInformationsLogService
    {
        IDataResult<SystemInformationsLog> GetById(string id);
        IDataResult<List<SystemInformationsLog>> GetAll();
        IDataResult<ICollection<SystemInformationsLog>> GetAllUnReadMessageWithPage(int page, int limit);
        IResult UpdateAllUnReadMessageById(string[] id);
        IResult Add(SystemInformationsLog log);
        IDataResult<ICollection<SystemInformationsLog>> GetAllUnReadMessageByStatus();
        IResult UpdateAllUnReadMessage();
        IResult UpdateUnreadMessage(string id);
        IResult Delete(SystemInformationsLog error);
    }
}
