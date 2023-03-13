using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{

    public class SystemInformationsLogManager : ISystemInformationsLogService
    {
        private readonly ISystemInformationsLogDal _systemInformationslogDal;
        public SystemInformationsLogManager(ISystemInformationsLogDal systemInformationslogDal)
        {

            _systemInformationslogDal = systemInformationslogDal;

        }
        [SecuredOperation("suser,admin,systemInformationsLog.Add")]
        public IResult Add(SystemInformationsLog log)
        {
            _systemInformationslogDal.Add(log);
            return new SuccessResult(Messages.NewErrorOccurred);
        }
        [SecuredOperation("suser,admin,systemInformationsLog.Get")]
        public IDataResult<List<SystemInformationsLog>> GetAll()
        {
            return new SuccessDataResult<List<SystemInformationsLog>>(_systemInformationslogDal.GetAllSystemInformationLogs(), Messages.Successful);
        }
        [SecuredOperation("suser,admin,systemInformationsLog.Get")]
        public IDataResult<SystemInformationsLog> GetById(string id)
        {
            return new SuccessDataResult<SystemInformationsLog>(_systemInformationslogDal.Get(p => p.Id == id), Messages.Successful);
        }

        

        [SecuredOperation("suser,admin,systemInformationsLog.Delete")]
        public IResult Delete(SystemInformationsLog error)
        {
            var result = _systemInformationslogDal.Delete(error);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);


        }
        [SecuredOperation("suser,admin,sytemInformationLog.Get")]
        public IDataResult<ICollection<SystemInformationsLog>> GetAllUnReadMessageByStatus()
        {
            var result = _systemInformationslogDal.GetAll(x => x.Status == false);
        
            return new SuccessDataResult<ICollection<SystemInformationsLog>>(result, Messages.Successful);
     
        }
        [SecuredOperation("suser,admin,sytemInformationLog.Get")]
        public IResult UpdateAllUnReadMessageById(string[] id)          
        {
            long result = 0;
            foreach (var informationLogId in id)
            {
                var systenInformationModel = _systemInformationslogDal.Get(x => x.Id == informationLogId);
                systenInformationModel.Status = true;
                result = _systemInformationslogDal.Update(systenInformationModel).MatchedCount;
            }
         
                if (result > 0)
                {
                    return new SuccessResult(Messages.UpdateSuccessful);
                }
          
          
            return new ErrorResult(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
        [SecuredOperation("suser,admin,sytemInformationLog.Get")]
        public IResult UpdateUnreadMessage(string id)
        {
            var systemInformationLogModel = _systemInformationslogDal.Get(x=> x.Id == id);
            systemInformationLogModel.Status = true;   
            var result = _systemInformationslogDal.Update(systemInformationLogModel);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
           return new ErrorResult(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
        [SecuredOperation("suser,admin,sytemInformationLog.Get")]
        public IDataResult<ICollection<SystemInformationsLog>> GetAllUnReadMessageWithPage(int page, int limit)
        {
            var result = _systemInformationslogDal.GetAllUnReadMessageWithPage(page, limit);
            return new SuccessDataResult<ICollection<SystemInformationsLog>>(result, Messages.Successful);
        }
        [SecuredOperation("suser,admin,sytemInformationLog.Get")]
        public IResult UpdateAllUnReadMessage()
        {
            long result = 0;
            var systemLogResult = _systemInformationslogDal.GetAll(x => x.Status == false);
            foreach (var systemLog in systemLogResult)
            {
                systemLog.Status = true;
                result = _systemInformationslogDal.Update(systemLog).MatchedCount;
            }
            if(result > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
    }
}
