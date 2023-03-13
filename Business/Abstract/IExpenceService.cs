using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IExpenceService
    {
        IResult Add(Expence entity);
        IResult Update(Expence entity);
        IResult Delete(string id);
        IDataResult<List<Expence>> GetAll();
        IDataResult<Expence> GetById(string id);
        IDataResult<Expence> GetByEmployeeId(string employeeId);

    }
}
