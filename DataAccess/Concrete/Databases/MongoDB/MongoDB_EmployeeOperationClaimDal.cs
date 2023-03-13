using Core.DataAccess.Databases;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using Entities.Concrete;
using Entities.Concrete.Simples;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EmployeeOperationClaimDal : MongoDB_RepositoryBase<EmployeeOperationClaim, MongoDB_Context<EmployeeOperationClaim, MongoDB_EmployeeOperationClaimCollection>>, IEmployeeOperationClaimDal
    {
        public List<EmployeeOperationClaimsEvolved> GetAllClaims()
        {
            List<EmployeeOperationClaim> _employeeOperationClaims = new List<EmployeeOperationClaim>();
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<Employee> _employees = new List<Employee>();
            List<EmployeeOperationClaimsEvolved> _employeeOperationClaimsEvoled = new List<EmployeeOperationClaimsEvolved>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            using (var employees = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                _employees = employees.collection.Find<Employee>(document => true).ToList();
            }

            using (var operationClamis = new MongoDB_Context<EmployeeOperationClaim, MongoDB_EmployeeOperationClaimCollection>())
            {
                _employeeOperationClaims = operationClamis.collection.Find<EmployeeOperationClaim>(document => true).ToList();
            }

            foreach (var employeeOperationClaim in _employeeOperationClaims)
            {
                var currentOperationClaim=_operationClaims.Where(o=>o.Id==employeeOperationClaim.OperationClaimId).FirstOrDefault();
                var currentEmployee=_employees.Where(e=>e.Id==employeeOperationClaim.EmployeeId).FirstOrDefault();

                if (currentEmployee != null && currentOperationClaim != null)
                {
                    EmployeeOperationClaimsEvolved employeeOperationClaimsEvoled = new EmployeeOperationClaimsEvolved { Id = employeeOperationClaim.Id, OperationClaim= currentOperationClaim.Name, OperationClaimId = currentOperationClaim.Id, Employee = currentEmployee.Name, EmployeeId = currentEmployee.Id };
                    _employeeOperationClaimsEvoled.Add(employeeOperationClaimsEvoled);

                }
            }
            return _employeeOperationClaimsEvoled;
        }
    }
}
