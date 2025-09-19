using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.User.Commands.Validators
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public ChangeUserPasswordValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidation();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MinimumLength(8).WithMessage(_stringLocalizer[SharedResourcesKeys.LessThanMinLength]);
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MinimumLength(8).WithMessage(_stringLocalizer[SharedResourcesKeys.LessThanMinLength]);
            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .Equal(x => x.NewPassword).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordsNotMatch]);
        }
        private void ApplyCustomValidation()
        {

        }
    }
}
