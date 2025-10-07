using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authentication.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                         IRequestHandler<SignInCommand, Response<JwtAuthResponse>>,
                                         IRequestHandler<RefreshTokenCommand, Response<JwtAuthResponse>>,
                                         IRequestHandler<SendResetPasswordCommand, Response<string>>,
                                         IRequestHandler<ResetPasswordCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                     UserManager<ApplicationUser> userManager,
                                     IMapper mapper,
                                     SignInManager<ApplicationUser> signInManager,
                                     IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }

        //Sign In
        public async Task<Response<JwtAuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userByUserName == null)
                return NotFound<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExists]);

            var result = await _signInManager.CheckPasswordSignInAsync(userByUserName, request.Password, true);

            //Check on email confirmation
            if (!userByUserName.EmailConfirmed)
                return BadRequest<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.PleaseConfirmEmail]);

            if (!result.Succeeded)
                return BadRequest<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.SignInFailed]);

            //Generate Token
            var jwtResponse = await _authenticationService.GetJwtToken(userByUserName);
            return Success(jwtResponse);
        }

        public async Task<Response<JwtAuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJwtToken(request.AccessToken);
            var (userId, refreshTokenExpiryDate) = await _authenticationService.ValidateOnDetails(jwtToken, request.AccessToken, request.RefreshToken);

            switch (userId)
            {
                case "Invalid Algorithm":
                    return Unauthorized<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.InvalidAlgorithm]);
                case "Token Is Not Expired":
                    return Unauthorized<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);
                case "Invalid Token Claims":
                    return Unauthorized<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.InvalidTokenClaims]);
                case "Refresh Token Is Not Found":
                    return Unauthorized<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case "Refresh Token Is Expired":
                    return Unauthorized<JwtAuthResponse>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound<JwtAuthResponse>();

            var result = await _authenticationService.GetRefreshToken(jwtToken, refreshTokenExpiryDate, user, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SendResetPasswordAsync(request.Email);
            switch (result)
            {
                case "Something Went Wrong While Updating The User":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongWhileUpdatingTheUser]);
                case "Something Went Wrong While Sending Email":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SomethingWentWrongWhileSendingEmail]);
                case "Failed":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.PleaseTryAgain]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.CodeSentSuccessfully]);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ResetPasswordAsync(request.Email, request.NewPassword);
            switch (result)
            {
                case "User Not Found":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailNotExists]);
                case "Failed":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.ResetPasswordProcessFailedPleaseTryAgain]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.ResetPasswordSuccessfully]);
        }
    }
}
