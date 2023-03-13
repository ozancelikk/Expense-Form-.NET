using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<EmployeeEvolved>> GetAll();
        IDataResult<Employee> GetById(string id);
        IDataResult<EmployeeEvolved> GetByEmployeeId(string id);
        IResult Add(Employee entity);
        IResult Update(Employee entity);
        IResult Delete(string id);
        IDataResult<Employee> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(Employee employee);
        IResult ChangePassword(EmployeeForChangePasswordDto employeeForRegisterDto);

    }
}
