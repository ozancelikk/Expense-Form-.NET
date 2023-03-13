using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeAuthManager : IEmployeeAuthService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeTokenHelper _employeetokenHelper;
        private readonly IEmployeeOperationClaimService _employeeOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IEmployeeLoginActivitiesService _employeeLoginActivities;
        public EmployeeAuthManager
            (IEmployeeService employeeService,
            IEmployeeTokenHelper tokenHelper, 
            IEmployeeOperationClaimService employeeOperationClaimService, 
            IOperationClaimService operationClaimService, 
            IEmployeeLoginActivitiesService employeeloginActivities)
        {
            _employeeService = employeeService;
            _employeetokenHelper = tokenHelper;
            _employeeOperationClaimService = employeeOperationClaimService;
            _operationClaimService = operationClaimService;
            _employeeLoginActivities = employeeloginActivities;
        }

        public IDataResult<EmployeeAccessToken> CreateAccessToken(Employee employee)
        {
            var claims = _employeeService.GetClaims(employee);
            var accessToken = _employeetokenHelper.CreateToken(employee, claims.Data);
            return new SuccessDataResult<EmployeeAccessToken>(accessToken, Messages.AccessTokenCreated);
        }

      

        public IDataResult<Employee> Login(EmployeeForLoginDto employeeForLoginDto)
        {
            var employeeToCheck = _employeeService.GetByMail(employeeForLoginDto.Email);
            if (employeeToCheck.Data==null )
            {
                return new ErrorDataResult<Employee>(Messages.MissingOrIncorrectEntry);
            }

            if (!HashingHelper.VerifyPasswordHash(employeeForLoginDto.Password,employeeToCheck.Data.PasswordHash,employeeToCheck.Data.PasswordSalt))
            {
                _employeeLoginActivities.Add(new EmployeeLoginActivities { DateTime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"),Employee=employeeForLoginDto.Email,Type="Login Failed" });
                return new ErrorDataResult<Employee>(Messages.MissingOrIncorrectEntry);
            }
            _employeeLoginActivities.Add(new EmployeeLoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Employee = employeeForLoginDto.Email, Type = "Login Success" });
            return new SuccessDataResult<Employee>(employeeToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<Employee> Register(EmployeeForRegisterDto employeeForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(employeeForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            _employeeService.Add(new Employee
            {
                Department = employeeForRegisterDto.Department,
                EMail = employeeForRegisterDto.Email,
                Name = employeeForRegisterDto.Name,
                Surname = employeeForRegisterDto.SurName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
            var employeeForDefaultOperationClaim = _employeeService.GetByMail(employeeForRegisterDto.Email);
            if (employeeForDefaultOperationClaim.Success)
            {
                var defaultClaim = _operationClaimService.GetByClaimName("employee");

                _employeeOperationClaimService.Add(new EmployeeOperationClaimDto
                {
                    OperationClaimId = defaultClaim.Data.Id,
                    EmployeeId = employeeForDefaultOperationClaim.Data.Id,
                });
            }
            return new SuccessDataResult<Employee>(employeeForDefaultOperationClaim.Data, Messages.AddingSuccessful);
        } 
        public IResult EmployeeExists(string email)
        {
            var result= _employeeService.GetByMail(email);
            if (result.Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }
    }
}
