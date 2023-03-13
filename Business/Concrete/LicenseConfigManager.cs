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
    public class LicenseConfigManager : ILicenseConfigService
    {
        private readonly ILicenseConfigDal _licenseConfigDal;
        public LicenseConfigManager(ILicenseConfigDal licenseConfigDal)
        {

            _licenseConfigDal = licenseConfigDal;

        }
        [SecuredOperation("suser")]
        [ValidationAspect(typeof(LicenseConfigValidator))]
        public IResult Add(LicenseConfig licenseConfig)
        {
            IResult result = BusinessRules.Run(LicenseConfigExists());

            if (result != null)
            {
                return result;
            }
            _licenseConfigDal.Add(licenseConfig);
            return new SuccessResult(Messages.NewErrorOccurred);
        }
        [SecuredOperation("suser,admin")]
        public IDataResult<List<LicenseConfig>> GetAll()
        {
            return new SuccessDataResult<List<LicenseConfig>>(_licenseConfigDal.GetAll(), Messages.Successful);
        }

        [SecuredOperation("suser,admin")]
        public IDataResult<LicenseConfig> Get()
        {
            return new SuccessDataResult<LicenseConfig>(_licenseConfigDal.Get(), Messages.Successful);
        }
        [SecuredOperation("suser,admin")]
        public IDataResult<LicenseConfig> GetById(string id)
        {
            return new SuccessDataResult<LicenseConfig>(_licenseConfigDal.Get(p => p.Id == id), Messages.Successful);
        }
        [SecuredOperation("suser")]
        [ValidationAspect(typeof(LicenseConfigValidator))]
        public IResult Update(LicenseConfig licenseConfig)
        {
            var result = _licenseConfigDal.Update(licenseConfig);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.ADeviceParserUpdated);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
        [SecuredOperation("suser")]
        public IResult Delete(LicenseConfig licenseConfig)
        {
            var result = _licenseConfigDal.Delete(licenseConfig);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);


        }

        private IResult LicenseConfigExists()
        {
            var result = GetAll();
            if (result.Data.Count > 0)
            {
                return new ErrorResult(Messages.LicenseConfigAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
