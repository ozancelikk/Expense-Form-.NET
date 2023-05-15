using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        List<PaymentGetDto> GetDetailWithPayment();
        List<PaymentGetDto> GetAllWithEmployee();
        List<PaymentGetDto> GetWithEmployeeId(string id);
    }
}
