using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(IFormFile file, UploadFile uploadFile);
        IResult Delete(UploadFile uploadFile);
        IResult Update(IFormFile file, UploadFile uploadFile);
        IDataResult<List<UploadFile>> GetAll();
        IDataResult<UploadFile> GetByImageId(string id);
        IDataResult<List<UploadFile>> GetByImagesByVouncherId(string vouncherId);

    }
}
