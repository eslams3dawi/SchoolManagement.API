using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authentication.Queries.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                         IRequestHandler<AuthorizeUserQuery, Response<string>>,
                                         IRequestHandler<ConfirmEmailQuery, Response<string>>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AuthenticationQueryHandler(IAuthenticationService authenticationService, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _authenticationService = authenticationService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);

            if (result == "Invalid Token")
                return Unauthorized<string>(_stringLocalizer[SharedResourcesKeys.InvalidToken]);

            return Success<string>(_stringLocalizer[SharedResourcesKeys.ValidToken]); //Token is valid
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ConfirmEmail(request.UserId, request.Code);

            if (result == "Email Confirmed")
                return Success<string>(_stringLocalizer[SharedResourcesKeys.EmailConfirmedSuccessfully]);

            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToConfirmEmail]);
        }
    }
}
