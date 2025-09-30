using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authorization.Commands.Handlers
{
    public class ClaimCommandHandler : ResponseHandler,
                                      IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        public ClaimCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }
        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "Something Went Wrong While Removing Old User Claims":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongWhileRemovingOldUserClaims]);
                case "Something Went Wrong While Adding User Claims":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongWhileAddingUserClaims]);
                case "Something Went Wrong In Database While Updating User Claims":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongInDatabaseWhileUpdatingUserClaims]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.ClaimsAddedSuccessfully]);
        }
    }
}
