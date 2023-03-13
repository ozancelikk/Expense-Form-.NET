using Core.Entities.Concrete.DBEntities;
using Core.Utilities.HardwareInfo.Components;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHardwareInformationService
    {
        IDataResult<List<CpuCore>> GetCpuCoreList();
        IDataResult<List<CoreCpuListDto>> GetCpuCoreListByDate(string date);
        IDataResult<List<MemoryStatusDto>> GetMemoryStatusListByDate(string date);
        IDataResult<List<HardwareInformation>> GetAll();
        IDataResult<List<HardwareInformation>> GetAllByDate(string date);
    }
}
