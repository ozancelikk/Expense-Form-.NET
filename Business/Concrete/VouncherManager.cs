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

namespace Business.Concrete
{
    public class VouncherManager : IVoucherService
    {
        private readonly IVouncherDal _vouncherDal;
        public VouncherManager(IVouncherDal vouncherDal)
        {
            _vouncherDal = vouncherDal;
        }
        //[SecuredOperation("suser,admin,employee,vouncher.Add")]
        public IResult Add(Vouncher entity)
        {

            IResult result = BusinessRules.Run(IfVouncherExists(entity.VouncherNo));

            if (result != null)
            {
                return result;
            }
            _vouncherDal.Add(entity);
            return new SuccessResult(Messages.AddingSuccessful);
        }
        [SecuredOperation("suser,admin,employee,vouncher.Delete")]
        public IResult Delete(string id)
        {
            var vouncher = GetById(id);
            if (vouncher.Data == null)
            {
                return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
            }
            var result = _vouncherDal.Delete(vouncher.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        //[SecuredOperation("suser,admin,employee,vouncher.Get")]
        public IDataResult<List<Vouncher>> GetAll()
        {
            return new SuccessDataResult<List<Vouncher>>(_vouncherDal.GetAll(), Messages.Successful);
        }

        public IDataResult<List<VouncherGetDto>> VouncherGetDto()
        {
            return new SuccessDataResult<List<VouncherGetDto>>(_vouncherDal.GetDetailWithVouncher(), Messages.Successful);
        }

        public IDataResult<Vouncher> GetByExpenceId(string id)
        {
            return new SuccessDataResult<Vouncher>(_vouncherDal.Get(t=>t.ExpenceId==id));
        }

        [SecuredOperation("suser,admin,employee,vouncher.Get")]
        public IDataResult<Vouncher> GetById(string id)
        {
            return new SuccessDataResult<Vouncher>(_vouncherDal.Get(t => t.Id == id), Messages.Successful);
        }
        [SecuredOperation("suser,admin,employee,vouncher.Update")]
        public IResult Update(Vouncher entity)
        {
            var result = _vouncherDal.Update(entity);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);

        }
        public IDataResult<List<Vouncher>> GetByEmployeeId(string id)
        {
            return new SuccessDataResult<List<Vouncher>>(_vouncherDal.GetAll(t=>t.EmployeeId==id), Messages.Successful);
        }
        private IResult IfVouncherExists(string vouncherNo)
        {
            var result = _vouncherDal.Get(r => r.VouncherNo == vouncherNo);
            if (result != null)
            {
                return new ErrorResult(Messages.VouncherAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<VouncherDetail>GetByVouncherId(string id)
        {
            return new SuccessDataResult<VouncherDetail>(_vouncherDal.GetWithVouncher(), Messages.Successful);
        }
    }
}
