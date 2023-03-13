using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var payment = GetById(id);
            if (payment.Data==null)
            {
                return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
            }
            var result = _paymentDal.Delete(payment.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(),Messages.Successful);
        }

        public IDataResult<List<Payment>> GetByEmployeeId(string employeeId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p=>p.EmployeeId== employeeId), Messages.Successful);     
        }

        public IDataResult<Payment> GetById(string id)
        {
           return new SuccessDataResult<Payment>(_paymentDal.Get(p=>p.Id== id), Messages.Successful);
        }

        public IDataResult<List<PaymentGetDto>> PaymentGetDto()
        {
            return new SuccessDataResult<List<PaymentGetDto>>(_paymentDal.GetDetailWithPayment(),Messages.Successful);
        }

        public IResult Update(Payment payment)
        {
            var result= _paymentDal.Update(payment);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
    }
}
