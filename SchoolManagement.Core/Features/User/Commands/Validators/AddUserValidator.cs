using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.User.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidation();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(75).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(75).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .EmailAddress().WithMessage(_stringLocalizer[SharedResourcesKeys.NotValid]);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .MinimumLength(8).WithMessage(_stringLocalizer[SharedResourcesKeys.LessThanMinLength]);
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordsNotMatch]);
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(200).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
        }
        private void ApplyCustomValidation()
        {

        }
    }
}
