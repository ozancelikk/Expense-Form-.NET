using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReportVoucherManager : IReportVoucherService
    {
       private readonly IReportVoucherDal _reportVoucherDal;
        public ReportVoucherManager(IReportVoucherDal reportVoucherDal)
        {
            _reportVoucherDal = reportVoucherDal;
        }

        public IDataResult<List<ReportVoucher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Vouncher>> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Vouncher>> GetByEMployeeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
