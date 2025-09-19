﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Authentication.Commands.Models;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Authentication.Commands.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public SignInValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidation();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(256).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength])
                .MinimumLength(10).WithMessage(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MinimumLength(8).WithMessage(_stringLocalizer[SharedResourcesKeys.LessThanMinLength]);
        }
        private void ApplyCustomValidation()
        {

        }
    }
}
