using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.HardwareInfo.Components;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IHardwareInformationDal : IEntityRepository<HardwareInformation>
    {
        SuccessDataResult<List<CpuCore>> GetCpuCoreList();
        SuccessDataResult<List<CoreCpuListDto>> GetCpuCoreListByDate(string date);
        SuccessDataResult<List<MemoryStatusDto>> GetMemoryStatusListByDate(string date);
    }
}
