using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ExpenceManager : IExpenceService
    {
        private readonly IExpenceDal _expenceDal;
        public ExpenceManager(IExpenceDal expenceDal)
        {
            _expenceDal = expenceDal;
        }

        public IResult Add(Expence entity)
        { 
            _expenceDal.Add(entity);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var expence = GetById(id);
            if (expence.Data==null)
            {
                return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
            }
            var result = _expenceDal.Delete(expence.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult <List<Expence>> GetAll()
        {
            return new SuccessDataResult<List<Expence>>(_expenceDal.GetAll(),Messages.Successful);
        }

        public IDataResult<Expence> GetByEmployeeId(string employeeId)
        {
            return new SuccessDataResult <Expence>(_expenceDal.Get(e=>e.EmployeeId==employeeId),Messages.Successful);    
        }

        public IDataResult<Expence> GetById(string id)
        {
            return new SuccessDataResult<Expence>(_expenceDal.Get(t=>t.Id==id),Messages.Successful);
        }

        public IResult Update(Expence entity)
        {
            var result = _expenceDal.Update(entity);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);   
        }
    }
}
