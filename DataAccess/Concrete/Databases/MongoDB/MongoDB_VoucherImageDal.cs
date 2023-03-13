using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_VoucherImageDal: MongoDB_RepositoryBase<UploadFile, MongoDB_Context<UploadFile, MongoDB_VoucherImageCollection>>, IVoucherImageDal
    {
    }
}
