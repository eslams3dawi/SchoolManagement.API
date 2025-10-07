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
                                         IRequestHandler<ConfirmEmailQuery, Response<string>>,
                                         IRequestHandler<ResetPasswordQuery, Response<string>>
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

            if (result == "Failed")
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToConfirmEmail]);

            return Success<string>(_stringLocalizer[SharedResourcesKeys.EmailConfirmedSuccessfully]);
        }

        public async Task<Response<string>> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ConfirmResetPasswordAsync(request.Code, request.Email);

            switch (result)
            {
                case "User Not Found":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailNotExists]);
                case "Not Matched":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InValidCode]);
            }

            return Success<string>(_stringLocalizer[SharedResourcesKeys.ValidCode]);
        }
    }
}
