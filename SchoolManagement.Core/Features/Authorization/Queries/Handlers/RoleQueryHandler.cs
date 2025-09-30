using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Models;
using SchoolManagement.Core.Features.Authorization.Queries.Responses;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Helpers.DTOs;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
                                    IRequestHandler<GetRolesQuery, Response<List<GetRolesResponse>>>,
                                    IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>,
                                    IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService, IMapper mapper, UserManager<ApplicationUser> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<List<GetRolesResponse>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.GetRolesAsync();

            var rolesMapper = _mapper.Map<List<GetRolesResponse>>(result);
            return Success(rolesMapper);
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.GetRoleByIdAsync(request.Id);
            if (result == null)
                return NotFound<GetRoleByIdResponse>(_stringLocalizer[SharedResourcesKeys.RoleNotFound]);

            var roleMapper = _mapper.Map<GetRoleByIdResponse>(result);

            return Success(roleMapper);
        }

        public async Task<Response<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return NotFound<ManageUserRolesResponse>(_stringLocalizer[SharedResourcesKeys.UserIdNotExists]);

            var result = await _authorizationService.GetManageUserRolesData(user);
            return Success(result);
        }
    }
}
