﻿
using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authentication.Queries.Models;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Features.Authentication.Queries.Validators
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public ConfirmEmailValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            ApplyValidation();
        }

        private void ApplyValidation()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }

    }
}
