using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }
        //[SecuredOperation("suser,admin")]
        [ValidationAspect(typeof(UserOperationClaimSimpleValidator))]
        public IResult Add(UserOperationClaimDto userOperationClaimSimple)
        {
            var result = BusinessRules.Run(CheckIfUserOperationClaimExists(userOperationClaimSimple));
            if (result == null)
            {
                UserOperationClaim userOperationClaim = new UserOperationClaim();
                userOperationClaim.UserId = userOperationClaimSimple.UserId;
                userOperationClaim.OperationClaimId = userOperationClaimSimple.OperationClaimId;
                _userOperationClaimDal.Add(userOperationClaim);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(result.Message);
            
        }
        [SecuredOperation("suser,admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
           var result = _userOperationClaimDal.Delete(userOperationClaim);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
            
        }
        [SecuredOperation("suser,admin")]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.Successful);
        }
        [SecuredOperation("suser,admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
           var result =  _userOperationClaimDal.Update(userOperationClaim);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
           
        }
        [SecuredOperation("suser,admin")]
        public IDataResult<UserOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(p => p.Id == id), Messages.Successful);
        }
        [SecuredOperation("suser,admin")]
        public IDataResult<List<UserOperationClaimsEvolved>> GetAllClaims()
        {
            return new SuccessDataResult<List<UserOperationClaimsEvolved>>(_userOperationClaimDal.GetAllClaims(), Messages.Successful);
        }

        private IResult CheckIfUserOperationClaimExists(UserOperationClaimDto userOperationClaimSimple)
        {
            var result = _userOperationClaimDal.GetAll(p => p.UserId == userOperationClaimSimple.UserId && p.OperationClaimId == userOperationClaimSimple.OperationClaimId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ThisOperationClaimAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }

    }
}
