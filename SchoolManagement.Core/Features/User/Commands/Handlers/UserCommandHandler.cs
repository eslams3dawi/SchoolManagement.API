using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                      IRequestHandler<AddUserCommand, Response<string>>,
                                      IRequestHandler<UpdateUserCommand, Response<string>>,
                                      IRequestHandler<DeleteUserCommand, Response<string>>,
                                      IRequestHandler<ChangeUserPasswordCommand, Response<string>>
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
            if (userByEmail != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailExists]);

            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userByUserName != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UsernameExists]);

            var UserMapper = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(UserMapper, request.Password);

            if (result.Succeeded)
                return Created<string>();
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddingFailed], result.Errors.Select(r => r.Description).ToList());
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userById = await _userManager.FindByIdAsync(request.Id);
            if (userById == null)
                return NotFound<string>();

            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName && u.Id != request.Id);
            if (userByUserName != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UsernameExists]);

            var userMapper = _mapper.Map(request, userById);
            var result = await _userManager.UpdateAsync(userMapper);

            if (result.Succeeded)
                return Updated<string>();
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdatingFailed], result.Errors.Select(r => r.Description).ToList());
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userById = await _userManager.FindByIdAsync(request.Id);
            if (userById == null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = await _userManager.DeleteAsync(userById);
            if (result.Succeeded)
                return Deleted<string>();
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletingFailed], result.Errors.Select(r => r.Description).ToList());
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userById = await _userManager.FindByIdAsync(request.Id);
            if (userById == null)
                return NotFound<string>();

            var result = await _userManager.ChangePasswordAsync(userById, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
                return Updated<string>();
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.ChangePasswordFailed], result.Errors.Select(r => r.Description).ToList());
        }
    }
}
