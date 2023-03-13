using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }
        [SecuredOperation("suser,admin,operationClaim.Get")]
        public IDataResult<OperationClaim> GetByClaimName(string claimName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(c => c.Name == claimName), Messages.Successful);
        }
        [SecuredOperation("suser,admin,operationClaim.Get")]
        public IDataResult<List<OperationClaim>> GetAll()
        {          
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.Successful);
        }
    }
}
