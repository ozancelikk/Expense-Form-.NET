using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TimeStampConfigValidator : AbstractValidator<TimeStampConfig>
    {
        public TimeStampConfigValidator()
        {
            RuleFor(t => t.TimeStampServer).NotEmpty();
            RuleFor(t => t.UserName).NotEmpty();
            RuleFor(t => t.Password).NotEmpty();

        }
    }
}
