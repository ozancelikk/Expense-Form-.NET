using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUploadReceiptImageService
    {
        IResult Add(IFormFile file, UploadReceiptImage uploadReceiptImage);
        IResult Delete(UploadReceiptImage uploadReceiptImage);
        IResult Update(IFormFile file, UploadReceiptImage uploadReceiptImage);
        IDataResult<List<UploadReceiptImage>> GetAll();
        IDataResult<UploadReceiptImage> GetByImageId(string id);
        IDataResult<List<UploadReceiptImage>> GetByImagesByReceiptId(string receiptId);
    }
}
