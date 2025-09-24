using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authorization.Commands.Validators
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplyValidation();
            ApplyCustomValidation();
        }

        public void ApplyValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }

        public void ApplyCustomValidation()
        {

        }
    }
}
