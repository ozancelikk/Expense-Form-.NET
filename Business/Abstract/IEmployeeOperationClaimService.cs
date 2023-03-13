using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeOperationClaimService
    {
        IDataResult<EmployeeOperationClaim> GetById(string id);
        IDataResult<List<EmployeeOperationClaimsEvolved>> GetAllClaims();
        IDataResult<List<EmployeeOperationClaim>> GetAll();
        IResult Add(EmployeeOperationClaimDto employeeOperationClaimSimple);
        IResult Delete(EmployeeOperationClaim employeeOperationClaim);
        IResult Update(EmployeeOperationClaim employeeOperationClaim);
    }
}
