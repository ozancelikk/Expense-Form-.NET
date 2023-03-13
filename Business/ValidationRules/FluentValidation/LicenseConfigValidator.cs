using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class LicenseConfigValidator : AbstractValidator<LicenseConfig>
    {
        public LicenseConfigValidator()
        {
            RuleFor(p => p.LicenseServerMethod).NotEmpty();
            RuleFor(p => p.LicenseServerAddress).NotEmpty();
      
        }
    }
}
