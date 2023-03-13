using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_UploadReceiptImageDal: MongoDB_RepositoryBase<UploadReceiptImage, MongoDB_Context<UploadReceiptImage, MongoDB_UploadReceiptImageCollection>>, IUploadReceiptImageDal
    {
    }
}
