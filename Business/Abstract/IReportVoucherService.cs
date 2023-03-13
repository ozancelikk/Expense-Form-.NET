using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReportVoucherService
    {
        IDataResult<List<ReportVoucher>> GetAll();
        IDataResult<List<Vouncher>> GetByEMployeeId(int id);
        IDataResult<List<Vouncher>> GetByDate(DateTime date);
    }
}
