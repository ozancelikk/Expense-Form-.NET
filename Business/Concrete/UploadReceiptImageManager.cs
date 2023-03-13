using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class UploadReceiptImageManager : IUploadReceiptImageService
    {
        IUploadReceiptImageDal _uploadReceiptImageDal;
        IFileHelper _fileHelper;
        public UploadReceiptImageManager(IUploadReceiptImageDal uploadReceiptImageDal, IFileHelper fileHelper)
        {
            _uploadReceiptImageDal = uploadReceiptImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, UploadReceiptImage uploadReceiptImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(uploadReceiptImage.ReceiptId));
            if (result != null)
            {
                return result;
            }
            uploadReceiptImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath2);
            uploadReceiptImage.Date = DateTime.Now;
            _uploadReceiptImageDal.Add(uploadReceiptImage);
            return new SuccessResult();
        }

        public IResult Delete(UploadReceiptImage uploadReceiptImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath2 + uploadReceiptImage.ImagePath);
            _uploadReceiptImageDal.Delete(uploadReceiptImage);
            return new SuccessResult();
        }

        public IDataResult<List<UploadReceiptImage>> GetAll()
        {
            return new SuccessDataResult<List<UploadReceiptImage>>(_uploadReceiptImageDal.GetAll());
        }

        public IDataResult<UploadReceiptImage> GetByImageId(string id)
        {
            return new SuccessDataResult<UploadReceiptImage>(_uploadReceiptImageDal.Get(i=>i.Id== id));
        }

        public IDataResult<List<UploadReceiptImage>> GetByImagesByReceiptId(string receiptId)
        {
            return new SuccessDataResult<List<UploadReceiptImage>>(_uploadReceiptImageDal.GetAll(i=>i.ReceiptId==receiptId));
        }

        public IResult Update(IFormFile file, UploadReceiptImage uploadReceiptImage)
        {
            uploadReceiptImage.ImagePath=_fileHelper.Update(file,PathConstants.ImagePath2+uploadReceiptImage.ImagePath,PathConstants.ImagePath2);
            _uploadReceiptImageDal.Update(uploadReceiptImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimit(string receiptId)
        {
            var result = _uploadReceiptImageDal.GetAll(x => x.ReceiptId == receiptId).Count;

            if (result >= 2)
            {
                return new ErrorResult("Bir Makbuzun en fazla 2 resmi olabilir");
            }
            return new SuccessResult();
        }
    }
}
