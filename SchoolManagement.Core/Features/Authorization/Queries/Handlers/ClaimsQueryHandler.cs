using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authorization.Queries.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Helpers.DTOs;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authorization.Queries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler,
                                      IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _user;
        private readonly IAuthorizationService _authorizationService;

        public ClaimsQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<ApplicationUser> user, IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _user = user;
            _authorizationService = authorizationService;
        }

        public async Task<Response<ManageUserClaimsResponse>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _user.FindByIdAsync(request.userId);
            if (user == null)
                return NotFound<ManageUserClaimsResponse>(_stringLocalizer[SharedResourcesKeys.UserIdNotExists]);

            var result = await _authorizationService.ManageUserClaimsData(user);
            return Success(result);
        }
    }
}
