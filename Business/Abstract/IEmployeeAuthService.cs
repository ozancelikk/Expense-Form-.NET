using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeAuthService
    {
        IDataResult<Employee> Register(EmployeeForRegisterDto employeeForRegisterDto);
        IDataResult<Employee> Login(EmployeeForLoginDto employeeForLoginDto);
        IResult EmployeeExists(string email);
        IDataResult<EmployeeAccessToken> CreateAccessToken(Employee employee);
        //IResult ForgotPassword(string eMail);
        //IResult ChangeForgottenPassword(ForgottenPassword forgottenPassword);
    }
}
