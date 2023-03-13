using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class VouncherImageManager: IImageService
    {
        IVoucherImageDal _voucherImageDal;
        IFileHelper _fileHelper;
        public VouncherImageManager(IVoucherImageDal voucherImageDal, IFileHelper fileHelper)
        {
            _voucherImageDal = voucherImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, UploadFile uploadFile)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(uploadFile.VoucherId));
            if (result != null)
            {
                return result;
            }
            uploadFile.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            uploadFile.Date = DateTime.Now;
            _voucherImageDal.Add(uploadFile);
            return new SuccessResult();
        }

        public IResult Delete(UploadFile uploadFile)
        {
            _fileHelper.Delete(PathConstants.ImagePath + uploadFile.ImagePath);
            _voucherImageDal.Delete(uploadFile);
            return new SuccessResult();
        }

        public IDataResult<List<UploadFile>> GetAll()
        {
            return new SuccessDataResult<List<UploadFile>>(_voucherImageDal.GetAll());
        }


        public IDataResult<UploadFile> GetByImageId(string id)
        {
            return new SuccessDataResult<UploadFile>(_voucherImageDal.Get(i => i.Id == id));
        }

        public IDataResult<List<UploadFile>> GetByImagesByVouncherId(string vouncherId)
        {
            return new SuccessDataResult<List<UploadFile>>(_voucherImageDal.GetAll(x => x.VoucherId == vouncherId));
        }

        public IResult Update(IFormFile file, UploadFile uploadFile)
        {
            uploadFile.ImagePath = _fileHelper.Update(file, PathConstants.ImagePath + uploadFile.ImagePath, PathConstants.ImagePath);
            _voucherImageDal.Update(uploadFile);
            return new SuccessResult();
        }

        private IResult CheckImageLimit(string vouncherId)
        {
            var result = _voucherImageDal.GetAll(x => x.VoucherId == vouncherId).Count;

            if (result >= 2)
            {
                return new ErrorResult("Bir Fişin en fazla 1 resmi olabilir");
            }
            return new SuccessResult();
        }
    }
}
