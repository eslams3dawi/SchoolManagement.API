using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<ApplicationUser> userManager, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //If email exists, return error
            var userByEmail = await _userManager.FindByEmailAsync(request.Email);
            var userByUserName = await _userManager.FindByNameAsync(request.UserName);

            if (userByEmail != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailExists]);
            if (userByUserName != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UsernameExists]);

            var UserMapper = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(UserMapper, request.Password);

            if (result.Succeeded)
                return Created<string>();

            return BadRequest<string>(result.Errors.FirstOrDefault().Description);
        }
    }
}
