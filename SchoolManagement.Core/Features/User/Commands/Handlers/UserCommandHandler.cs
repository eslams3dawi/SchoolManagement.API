using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Identity;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Service.Interfaces;

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
        private readonly IHttpContextAccessor _accessor;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<ApplicationUser> userManager, IMapper mapper, IHttpContextAccessor accessor, IEmailService emailService, ApplicationDbContext context) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _mapper = mapper;
            _accessor = accessor;
            _emailService = emailService;
            _context = context;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                //Validation
                var userByEmail = await _userManager.FindByEmailAsync(request.Email);
                if (userByEmail != null)
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailExists]);

                var userByUserName = await _userManager.FindByNameAsync(request.UserName);
                if (userByUserName != null)
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UsernameExists]);

                //Mapping and Creating
                var UserMapper = _mapper.Map<ApplicationUser>(request);
                var result = await _userManager.CreateAsync(UserMapper, request.Password);

                //Send email confirmation//
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(UserMapper);
                var accessor = _accessor.HttpContext.Request;
                var url = $"To confirm you email, click on this link <a href=\"{accessor.Scheme + "://" + accessor.Host + "/" + $"Api/V1/Authentication/Confirm-Email?UserId={UserMapper.Id}&Code={code}"}\">Confirm</a> ";

                var emailResult = await _emailService.SendEmailAsync(UserMapper.Email, "Email Confirmation", url);
                if (emailResult != "Email Sent Successfully")
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToSendEmail]);
                //                      //

                if (result.Succeeded)
                {
                    await transaction.CommitAsync();
                    return Created<string>();
                }

                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddingFailed], result.Errors.Select(r => r.Description).ToList());
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddingFailed]);
            }
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
