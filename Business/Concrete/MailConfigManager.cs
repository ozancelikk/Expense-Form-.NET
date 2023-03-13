using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MailConfigManager : IMailConfigService
    {
        private readonly IEMailConfigDal _eMailConfigDal;
        public MailConfigManager(IEMailConfigDal eMailConfigDal)
        {
            _eMailConfigDal = eMailConfigDal;
        }
        [SecuredOperation("suser,admin")]
        [ValidationAspect(typeof(EMailConfigurationValidator))]
        public IResult Add(MailConfig eMailConfig)
        {
            IResult result = BusinessRules.Run(MailConfigExists());

            if (result != null)
            {
                return result;
            }
            _eMailConfigDal.Add(eMailConfig);
            return new SuccessResult(Messages.Successful);

        }
        [SecuredOperation("suser,admin")]
        [ValidationAspect(typeof(EMailConfigurationValidator))]
        public IResult Delete(MailConfig eMailConfig)
        {
            var result = _eMailConfigDal.Delete(eMailConfig);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.EmailConfigDeleted);
            }

            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        [SecuredOperation("suser,admin")]
        [ValidationAspect(typeof(EMailConfigurationValidator))]
        public IResult Update(MailConfig eMailConfig)
        {
            var result = _eMailConfigDal.Update(eMailConfig);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.ADeviceParserUpdated);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }

        [SecuredOperation("suser,admin")]
        public IDataResult<List<MailConfig>> GetAll()
        {
            return new SuccessDataResult<List<MailConfig>>(_eMailConfigDal.GetAll(), Messages.Successful);
        }


        [SecuredOperation("suser,admin")]
        public IDataResult<MailConfig> Get()
        {
            return new SuccessDataResult<MailConfig>(_eMailConfigDal.Get(), Messages.Successful);
        }

        [SecuredOperation("suser,admin")]
        public IDataResult<MailConfig> GetById(string id)
        {
            return new SuccessDataResult<MailConfig>(_eMailConfigDal.Get(p => p.Id == id), Messages.Successful);
        }

        [SecuredOperation("suser,admin")]
        public IDataResult<MailConfig> GetByEmail(string email)
        {
            return new SuccessDataResult<MailConfig>(_eMailConfigDal.Get(p => p.From == email), Messages.Successful);
        }

        private IResult MailConfigExists()
        {
            var result = GetAll();
            if (result.Data.Count > 0)
            {
                return new ErrorResult(Messages.LicenseConfigAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }

    }
}
