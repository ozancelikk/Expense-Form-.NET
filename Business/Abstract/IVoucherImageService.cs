using Core.Extensions;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVoucherImageService
    {
        IResult Add(IFormFile file, string voucherId);
        IResult Update(IFormFile file, string id);
        IResult Delete(string id);

        IDataResult<List<UploadFile>> GetAll();
        IResult GetByImageId(string imageId);
    }
}
