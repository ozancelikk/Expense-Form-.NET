using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReceiptService
    {
        IDataResult<List<Receipt>> GetAll();
        IDataResult<Receipt> GetById(string id);
        IDataResult<List<ReceiptGetDto>> ReceiptGetDto();
        IDataResult<List<Receipt>> GetAllByEmployeeId(string employeeId);
        IResult Add(Receipt entity);
        IResult Update(Receipt entity);
        IResult Delete(string id);
    }
}
