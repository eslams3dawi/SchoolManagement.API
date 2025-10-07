using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authentication.Queries.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authentication.Queries.Validators
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordQuery>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthenticationService _authenticationService;

        public ResetPasswordValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthenticationService authenticationService)
        {
            _stringLocalizer = stringLocalizer;
            _authenticationService = authenticationService;
            ApplyValidation();
            ApplyCustomValidation();
        }

        private void ApplyValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }

        private void ApplyCustomValidation()
        {
            //RuleFor(x => x.Email)
            //    .MustAsync(async (Key, CancellationToken) => await _authenticationService.IsEmailExists(Key))
            //    .WithMessage(_stringLocalizer[SharedResourcesKeys.EmailNotExists]);
        }
    }
}
