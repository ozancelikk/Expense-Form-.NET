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
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_EmployeeDal : MongoDB_RepositoryBase<Employee, MongoDB_Context<Employee, MongoDB_EmployeeCollection>>, IEmployeeDal
    {
        public void DeleteClaims(Employee employee)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            using (var operationClaims = new MongoDB_Context<EmployeeOperationClaim, MongoDB_EmployeeOperationClaimCollection>()) 
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(c => c.EmployeeId == employee.Id);
            }
        }

        public List<EmployeeEvolved> GetAllWithClaims()
        {
            List<EmployeeEvolved> _employeeEvlolveds = new List<EmployeeEvolved>();
            List<Employee> _employees = new List<Employee>();
            using (var employees=new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employees.GetMongoDBCollection();
                _employees = employees.collection.Find<Employee>(document => true).ToList();            
            }

            foreach (var employee in _employees)
            {
                EmployeeEvolved employeeEvolved = new EmployeeEvolved
                {
                    Id = employee.Id,
                    Email = employee.EMail,
                    Name=employee.Name,
                    Surname= employee.Surname,
                    Department= employee.Department,
                    OperationClaims=GetClaims(employee),
                    
                    
                };
                _employeeEvlolveds.Add(employeeEvolved);
            }
            return _employeeEvlolveds; 
          
        }

        public List<OperationClaim> GetClaims(Employee employee)
        {
            List<OperationClaim> _operationClaims=new List<OperationClaim>();
            List<EmployeeOperationClaim> _employeeOperationClaim = new List<EmployeeOperationClaim>();
            List<OperationClaim> _currentUserOperationClaims =new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>()) 
            {
                operationClaims.GetMongoDBCollection();
                _operationClaims=operationClaims.collection.Find<OperationClaim>(document=>true).ToList();
            }
            using (var operationClaims = new MongoDB_Context<EmployeeOperationClaim, MongoDB_EmployeeOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _employeeOperationClaim = operationClaims.collection.Find<EmployeeOperationClaim>(document => true).ToList();
            }
            
            var employeeOperationClaims=_employeeOperationClaim.Where(e=>e.EmployeeId==employee.Id).ToList();
            foreach (var userOperationClaim in employeeOperationClaims)
            {
                _currentUserOperationClaims.Add(_operationClaims.Where(oc => oc.Id == userOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentUserOperationClaims;
        }

        public EmployeeEvolved GetWithClaims(string EmployeeId)
        {
            Employee employee=new Employee();
            using (var employees = new MongoDB_Context<Employee, MongoDB_EmployeeCollection>())
            {
                employees.GetMongoDBCollection();
                employee = employees.collection.Find<Employee>(document => true).FirstOrDefault();
            }


            EmployeeEvolved employeeEvolved = new EmployeeEvolved
            {
                Id=employee.Id,
                Email=employee.EMail,
                Name=employee.Name,
                Surname=employee.Surname,
                Department=employee.Department,
                OperationClaims=GetClaims(employee)
            };
            return employeeEvolved;
        }
    }
}