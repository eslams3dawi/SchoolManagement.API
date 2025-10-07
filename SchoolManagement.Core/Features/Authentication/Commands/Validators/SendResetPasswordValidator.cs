using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authentication.Commands.Validators
{
    public class SendResetPasswordValidator : AbstractValidator<SendResetPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthenticationService _authenticationService;

        public SendResetPasswordValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthenticationService authenticationService)
        {
            _stringLocalizer = stringLocalizer;
            _authenticationService = authenticationService;
            ApplyValidationRules();
            ApplyCustomValidation();
        }

        private void ApplyValidationRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }
        private void ApplyCustomValidation()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (Key, CancellationToken) => await _authenticationService.IsEmailExists(Key))
                .WithMessage(_stringLocalizer.GetString(SharedResourcesKeys.EmailNotExists));
        }
    }
}
