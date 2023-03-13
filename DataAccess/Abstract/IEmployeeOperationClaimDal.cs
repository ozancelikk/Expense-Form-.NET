using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEmployeeOperationClaimDal:IEntityRepository<EmployeeOperationClaim>
    {
        List<EmployeeOperationClaimsEvolved> GetAllClaims();
    }
}
