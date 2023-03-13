using Core.Entities.Concrete;
using Entities.Concrete.Simples;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.OperationClaimId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
    public class UserOperationClaimSimpleValidator : AbstractValidator<UserOperationClaimDto>
    {
        public UserOperationClaimSimpleValidator()
        {
            RuleFor(p => p.OperationClaimId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            
        }
    }
}
