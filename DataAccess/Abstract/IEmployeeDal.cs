using Core.DataAccess.Databases;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concrete.Simples;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal:IEntityRepository<Employee>
    {
        List<OperationClaim> GetClaims(Employee employee);
        List<EmployeeEvolved> GetAllWithClaims();
        EmployeeEvolved GetWithClaims(string EmployeeId);
        void DeleteClaims(Employee employee);

    }
}
