using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Email.Commands.Models;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Email.Commands.Validators
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public SendEmailValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidation();
            ApplyCustomValidation();
        }

        private void ApplyValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }
        private void ApplyCustomValidation()
        {

        }
    }
}
