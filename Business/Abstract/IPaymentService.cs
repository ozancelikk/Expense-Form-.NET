using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(string id);

        IDataResult<List<PaymentGetDto>> PaymentGetDto();
        IDataResult <List<PaymentGetDto>> GetAll();
        IDataResult <Payment> GetById(string id);
        IDataResult<List<Payment>> GetByEmployeeId(string employeeId);
    }
}
