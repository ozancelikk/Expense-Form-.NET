using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerInformationService
    {
        IDataResult<CustomerInformation> GetById(string id);
        IDataResult<List<CustomerInformation>> GetAll();
        IResult Update(CustomerInformation usedDevice);
        IResult Add(CustomerInformation usedDeviceSimple);
        IDataResult<CustomerInformation> Get();
    }
}
