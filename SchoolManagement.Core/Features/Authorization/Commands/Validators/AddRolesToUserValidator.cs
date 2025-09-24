using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authorization.Commands.Validators
{
    public class AddRolesToUserValidator : AbstractValidator<AddRolesToUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        public AddRolesToUserValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplyValidation();
            ApplyCustomValidation();
        }

        public void ApplyValidation()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }

        public void ApplyCustomValidation()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsUserIdExists(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleExists]);
            RuleForEach(x => x.Roles)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleNameExists(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleExists]);
        }
    }
}
