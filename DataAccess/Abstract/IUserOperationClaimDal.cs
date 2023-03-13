using Core.DataAccess.Databases;
using Core.Entities.Concrete;
using Entities.Concrete.Simples;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimsEvolved> GetAllClaims();
    }
}
