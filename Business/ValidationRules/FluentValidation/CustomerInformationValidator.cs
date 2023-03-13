using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerInformationValidator : AbstractValidator<CustomerInformation>
    {
        public CustomerInformationValidator()
        {
            RuleFor(p => p.Company).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.EMail).NotEmpty();
            RuleFor(p => p.EMail).EmailAddress();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.City).NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
            RuleFor(p => p.State).NotEmpty();
            RuleFor(p => p.Phone).NotEmpty();            
            RuleFor(p => p.Comments).MaximumLength(250);

        }
    }
}
