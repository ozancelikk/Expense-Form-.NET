using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface ILicenseConfigService
    {
        IDataResult<LicenseConfig> GetById(string id);
        IDataResult<List<LicenseConfig>> GetAll();
        IResult Add(LicenseConfig error);
        IResult Update(LicenseConfig licenseConfig);
        IResult Delete(LicenseConfig licenseConfig);
        IDataResult<LicenseConfig> Get();
    }
}
