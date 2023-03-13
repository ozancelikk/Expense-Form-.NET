using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal= employeeDal;
        }
        [SecuredOperation("suser,admin,employee.Add")]
        public IResult Add(Employee entity)
        {
            IResult result = BusinessRules.Run();
            if (result!=null)
            {
                return result;
            }
            _employeeDal.Add(entity);
            return new SuccessResult(Messages.AddingSuccessful);
        }
        [SecuredOperation("suser,admin,employee.Delete")]
        public IResult Delete(string id)
        {
            var employee =GetById(id);
            if (employee.Data==null)
            {
                return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
            }
            var result = _employeeDal.Delete(employee.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        //[SecuredOperation("suser,admin,employee.Get")]
        public IDataResult<List<EmployeeEvolved>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeEvolved>>(_employeeDal.GetAllWithClaims(),Messages.Successful);
        }
        public IDataResult<Employee> GetById(string id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.Id == id), Messages.Successful);
        }
        public IDataResult<EmployeeEvolved> GetByEmployeeId(string id)
        {
            return new SuccessDataResult<EmployeeEvolved>(_employeeDal.GetWithClaims(id), Messages.Successful);
        }
        public IDataResult<Employee> GetByMail(string email)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.EMail == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(Employee employee)
        {
            return new SuccessDataResult<List<OperationClaim>>(_employeeDal.GetClaims(employee), Messages.Successful);
        }

        [SecuredOperation("suser,admin,employee.Update")]
        public IResult Update(Employee entity)
        {
            var result = _employeeDal.Update(entity);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }

        public IResult ChangePassword(EmployeeForChangePasswordDto employeeForRegisterDto)
        {
            var employeeToCheck = GetByMail(employeeForRegisterDto.Email);
            if (employeeToCheck.Data==null)
            {
                return new ErrorDataResult<Employee>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(employeeForRegisterDto.OldPassword, employeeToCheck.Data.PasswordHash,employeeToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<Employee>(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(employeeForRegisterDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

            employeeToCheck.Data.PasswordHash= passwordHash;
            employeeToCheck.Data.PasswordSalt= passwordSalt;
            var result = _employeeDal.Update(employeeToCheck.Data);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }
    }
}
