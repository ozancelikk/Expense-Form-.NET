using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IVouncherDal : IEntityRepository<Vouncher>
    {
        List<VouncherGetDto> GetDetailWithVouncher();
        List<VouncherGetDto> GetDetailByVouncherId(string id);
        VouncherDetail GetWithVouncher();
    }
}
