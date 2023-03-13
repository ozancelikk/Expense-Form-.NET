using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class ReceiptManager : IReceiptService
    {
        IReceiptDal _receiptdal;
        public ReceiptManager(IReceiptDal receiptDal)
        {
            _receiptdal = receiptDal;
        }
        [SecuredOperation("suser,admin,receipt.Add,employee")]
        [BusinessEmployeeResultAspect("receipt-add")]
        public IResult Add(Receipt entity)
        {
            IResult result = BusinessRules.Run();
            if(result!=null)
            {
                return result;
            }
            _receiptdal.Add(entity);
            return new SuccessResult(Messages.AddingSuccessful);
        }
        [SecuredOperation("suser,admin,receipt.Delete")]
        public IResult Delete(string id)
        {
            var receipt=GetById(id);
            if (receipt.Data==null)
            {
                return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
            }
            var result = _receiptdal.Delete(receipt.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        [SecuredOperation("suser,admin,receipt.Get,employee")]
        //[BusinessEmployeeResultAspect("receipt-getall")]
        public IDataResult<List<Receipt>> GetAll()
        {
            return new SuccessDataResult<List<Receipt>>(_receiptdal.GetAll(), Messages.Successful);
        }
        public IDataResult<List<Receipt>> GetAllByEmployeeId(string employeeId)
        {
            return new SuccessDataResult<List<Receipt>>(_receiptdal.GetAll(r=> r.EmployeeId == employeeId), Messages.Successful);
        }

        [SecuredOperation("suser,admin,receipt.Get,employee")]
        public IDataResult<Receipt> GetByEmployeeId(string employeeId)
        {
            return new SuccessDataResult<Receipt>(_receiptdal.Get(r => r.EmployeeId == employeeId), Messages.Successful);
        }
        [SecuredOperation("suser,admin,receipt.Get")]
        public IDataResult<Receipt> GetById(string id)
        {
            return new SuccessDataResult<Receipt>(_receiptdal.Get(r=>r.Id==id),Messages.Successful);
        }

        public IDataResult<List<ReceiptGetDto>> ReceiptGetDto()
        {
            return new SuccessDataResult<List<ReceiptGetDto>>(_receiptdal.GetDetailWithReceipt(), Messages.Successful);
        }

        [SecuredOperation("suser,admin,receipt.Update")]
        public IResult Update(Receipt entity)
        {
            var result=_receiptdal.Update(entity);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
    }
}
