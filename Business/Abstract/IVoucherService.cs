using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVoucherService
    {
        IDataResult<List<Vouncher>> GetAll();
        IDataResult<Vouncher> GetById(string id);
        IDataResult <VouncherDetail> GetByVouncherId(string id);
        IDataResult<Vouncher> GetByExpenceId(string id);
        IDataResult<List<Vouncher>>GetByEmployeeId(string id);
        IDataResult<List<VouncherGetDto>> VouncherGetDto();
        IResult Add(Vouncher entity);
        IResult Update(Vouncher entity);
        IResult Delete(string id);
    }
}
