﻿using Core.DataAccess.Databases;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IVoucherImageDal:IEntityRepository<UploadFile>
    {
    }
}
