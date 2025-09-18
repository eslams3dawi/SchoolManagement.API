using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.User.Commands.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UpdateUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
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
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(200).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MinimumLength(11).WithMessage(_stringLocalizer[SharedResourcesKeys.LessThanMinLength])
                .MaximumLength(15).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
        }
        private void ApplyCustomValidation()
        {

        }
    }
}
