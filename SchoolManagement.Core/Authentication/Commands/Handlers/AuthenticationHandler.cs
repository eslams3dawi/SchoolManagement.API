using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Authentication.Commands.Models;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Identity;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Authentication.Commands.Handlers
{
    public class AuthenticationHandler : ResponseHandler,
                                         IRequestHandler<SignInCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationHandler(IStringLocalizer<SharedResources> stringLocalizer,
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
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userByUserName == null)
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExists]);

            var result = await _signInManager.CheckPasswordSignInAsync(userByUserName, request.Password, true);

            if (!result.Succeeded)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SignInFailed]);

            //Generate Token
            var token = await _authenticationService.GenerateJwtToken(userByUserName);
            return Success(token);
        }
    }
}
