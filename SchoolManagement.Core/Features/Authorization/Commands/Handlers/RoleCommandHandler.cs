using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
                                      IRequestHandler<AddRoleCommand, Response<string>>,
                                      IRequestHandler<UpdateRoleCommand, Response<string>>,
                                      IRequestHandler<DeleteRoleCommand, Response<string>>,
                                      IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        public RoleCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Created")
                return Created<string>();

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "Something Went Wrong While Removing Old User Roles":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongWhileRemovingOldUserRoles]);
                case "Something Went Wrong While Adding User Roles":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongWhileAddingUserRoles]);
                case "Something Went Wrong In Database While Updating User Roles":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongInDatabaseWhileUpdatingUserRoles]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.RolesAddedSuccessfully]);
        }

        public async Task<Response<string>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateRoleAsync(request);
            if (result == "Updated")
                return Updated<string>();
            else if (result == "Not Found")
                return NotFound<string>();

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);

            if (result == "Deleted")
                return Deleted<string>();
            else if (result == "Not Found")
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.RoleNotFound]);
            else if (result == "Users Use This Role")
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.CanNotDeleteUsedRole]);

            return BadRequest<string>();
        }
    }
}
