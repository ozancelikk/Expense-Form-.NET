using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.HardwareInfo.Components;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HardwareınformationManager : IHardwareInformationService
    {
        private IHardwareInformationDal _hardwareInformationDal;
        public HardwareınformationManager(IHardwareInformationDal hardwareInformationDal)
        {
            _hardwareInformationDal = hardwareInformationDal;
        }

        [SecuredOperation("suser,admin,dashboard.Get")]
        public IDataResult<List<HardwareInformation>> GetAll()
        {
            return new SuccessDataResult<List<HardwareInformation>>(_hardwareInformationDal.GetAll(), Messages.Successful);
        }

        [SecuredOperation("suser,admin,dashboard.Get")]
        public IDataResult<List<HardwareInformation>> GetAllByDate(string date)
        {
            return new SuccessDataResult<List<HardwareInformation>>(_hardwareInformationDal.GetAll(r => r.Date == date), Messages.Successful);
        }

        [SecuredOperation("suser,admin,HardwareInformation.Get")]
        public IDataResult<List<CpuCore>> GetCpuCoreList()
        {

            return _hardwareInformationDal.GetCpuCoreList();
        }
        [SecuredOperation("suser,admin,HardwareInformation.Get")]
        public IDataResult<List<CoreCpuListDto>> GetCpuCoreListByDate(string date)
        {
            return _hardwareInformationDal.GetCpuCoreListByDate(date);
        }
        [SecuredOperation("suser,admin,HardwareInformation.Get")]
        public IDataResult<List<MemoryStatusDto>> GetMemoryStatusListByDate(string date)
        {
            return _hardwareInformationDal.GetMemoryStatusListByDate(date);
        }
    }
}
