using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.HardwareInfo.Components;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_HardwareInformationDal : MongoDB_RepositoryBase<HardwareInformation, MongoDB_Context<HardwareInformation, MongoDB_HardwareInformationCollection>>, IHardwareInformationDal
    {
        public SuccessDataResult<List<CpuCore>> GetCpuCoreList()
        {
            List<CpuCore> cpuCoreList = new List<CpuCore>();
            using (var hardwareInformation = new MongoDB_Context<HardwareInformation, MongoDB_HardwareInformationCollection>())
            {
                cpuCoreList = hardwareInformation.collection.Find(u => true).ToList().Select(h => h.CpuCoreList).FirstOrDefault();
            }
            return new SuccessDataResult<List<CpuCore>>(cpuCoreList);
        }

        public SuccessDataResult<List<CoreCpuListDto>> GetCpuCoreListByDate(string date)
        {
            List<CoreCpuListDto> cpuCoreList = new List<CoreCpuListDto>();
            using (var hardwareInformation = new MongoDB_Context<HardwareInformation, MongoDB_HardwareInformationCollection>())
            {
                var result = hardwareInformation.collection.Find(u => u.Date == date).ToList();
                cpuCoreList = result.Select(h => new CoreCpuListDto{ CpuCoreList = h.CpuCoreList,Date = h.Date,Time = h.Time}).ToList();

            }
            return new SuccessDataResult<List<CoreCpuListDto>>(cpuCoreList);
        }


        public SuccessDataResult<List<MemoryStatusDto>> GetMemoryStatusListByDate(string date)
        {
            List<MemoryStatusDto> cpuCoreList = new List<MemoryStatusDto>();
            using (var hardwareInformation = new MongoDB_Context<HardwareInformation, MongoDB_HardwareInformationCollection>())
            {
                var result = hardwareInformation.collection.Find(u => u.Date == date).ToList();
                cpuCoreList = result.Select(h => new MemoryStatusDto { MemoryStatus = h.MemoryStatus, Date = h.Date, Time = h.Time }).ToList();

            }
            return new SuccessDataResult<List<MemoryStatusDto>>(cpuCoreList);
        }
    }
}
