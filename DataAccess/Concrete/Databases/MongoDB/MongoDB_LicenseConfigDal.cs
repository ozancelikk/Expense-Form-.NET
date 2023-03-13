using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_LicenseConfigDal : MongoDB_RepositoryBase<LicenseConfig, MongoDB_Context<LicenseConfig, MongoDB_LicenseConfigCollection>>, ILicenseConfigDal
    {
    }
}
