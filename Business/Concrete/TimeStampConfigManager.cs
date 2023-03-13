using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TimeStampConfigManager : ITimeStampConfigService
    {
        private readonly ITimeStampConfigDal _timeStampConfigDal;
        public TimeStampConfigManager(ITimeStampConfigDal timeStampConfigDal)
        {
            _timeStampConfigDal = timeStampConfigDal;
        }
        [SecuredOperation("suser")]
        public IResult Add(TimeStampConfig timeStamp)
        {
            IResult result = BusinessRules.Run(TimeStampExists());

            if (result != null)
            {
                return result;
            }
            _timeStampConfigDal.Add(timeStamp);
            return new SuccessResult(Messages.AddingSuccessful);
        }
        [SecuredOperation("suser")]
        public IResult Delete(TimeStampConfig timeStamp)
        {
          var result =  _timeStampConfigDal.Delete(timeStamp);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        [SecuredOperation("suser")]
        public IDataResult<List<TimeStampConfig>> GetAll()
        {
            return new SuccessDataResult<List<TimeStampConfig>>(_timeStampConfigDal.GetAll(), Messages.Successful);
        }
        [SecuredOperation("suser")]
        public IDataResult<TimeStampConfig> Get()
        {
            return new SuccessDataResult<TimeStampConfig>(_timeStampConfigDal.Get(), Messages.Successful);
        }
        [SecuredOperation("suser")]
        public IDataResult<TimeStampConfig> GetById(string id)
        {
            return new SuccessDataResult<TimeStampConfig>(_timeStampConfigDal.Get(t => t.Id == id), Messages.Successful);
        }
        [SecuredOperation("suser")]
        public IResult Update(TimeStampConfig timeStamp)
        {
          var result = _timeStampConfigDal.Update(timeStamp);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
  
        }
      

      private IResult TimeStampExists()
        {
            var result = GetAll();
            if (result.Data.Count > 0)
            {
                return new ErrorResult(Messages.TimeStampLimitExceded);
            }

            return new SuccessResult(Messages.Successful);
        }
    }
}
