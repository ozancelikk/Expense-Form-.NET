using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITimeStampConfigService
    {
        IDataResult<TimeStampConfig> GetById(string id);
        IDataResult<List<TimeStampConfig>> GetAll();
        IResult Add(TimeStampConfig timeStamp);
        IResult Update(TimeStampConfig timeStamp);
        IResult Delete(TimeStampConfig timeStamp);
        IDataResult<TimeStampConfig> Get();
    }
}
