using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeOperationClaimManager : IEmployeeOperationClaimService
    {
        private readonly IEmployeeOperationClaimDal _employeeOperationClaimDal;
        public EmployeeOperationClaimManager(IEmployeeOperationClaimDal employeeOperationClaimDal)
        {
            _employeeOperationClaimDal = employeeOperationClaimDal;
        }

        public IResult Add(EmployeeOperationClaimDto employeeOperationClaimSimple)
        {
            var result = BusinessRules.Run(CheckIfEmployeeOperationClaimExists(employeeOperationClaimSimple));
            if (result==null)
            {
                EmployeeOperationClaim employeeOperationClaim = new EmployeeOperationClaim();
                employeeOperationClaim.EmployeeId = employeeOperationClaimSimple.EmployeeId;
                employeeOperationClaim.OperationClaimId = employeeOperationClaimSimple.OperationClaimId;
                _employeeOperationClaimDal.Add(employeeOperationClaim);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(result.Message);

        }
        [SecuredOperation("suser,admin")]
        public IResult Delete(EmployeeOperationClaim employeeOperationClaim)
        {
            var result= _employeeOperationClaimDal.Delete(employeeOperationClaim);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }
        [SecuredOperation("suser,admin")]
        public IDataResult<List<EmployeeOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeOperationClaim>>(_employeeOperationClaimDal.GetAll(),Messages.Successful);
        }

        [SecuredOperation("suser,admin")]
        public IDataResult<List<EmployeeOperationClaimsEvolved>> GetAllClaims()
        {
            return new SuccessDataResult<List<EmployeeOperationClaimsEvolved>>(_employeeOperationClaimDal.GetAllClaims(), Messages.Successful);
        }

        [SecuredOperation("suser,admin")]
        public IDataResult<EmployeeOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<EmployeeOperationClaim>(_employeeOperationClaimDal.Get(e => e.Id == id), Messages.Successful);
        }

        [SecuredOperation("suser,admin")]
        public IResult Update(EmployeeOperationClaim employeeOperationClaim)
        {
           
            var result=_employeeOperationClaimDal.Update(employeeOperationClaim);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }

        [SecuredOperation("suser,admin")]
        private IResult CheckIfEmployeeOperationClaimExists(EmployeeOperationClaimDto employeeOperationClaimSimple)
        {
            var result= _employeeOperationClaimDal.GetAll(e=>e.EmployeeId==employeeOperationClaimSimple.EmployeeId && e.OperationClaimId==employeeOperationClaimSimple.OperationClaimId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ThisOperationClaimAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }
    }
}
