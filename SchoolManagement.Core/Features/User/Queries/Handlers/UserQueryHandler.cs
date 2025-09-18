using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Queries.Models;
using SchoolManagement.Core.Features.User.Queries.Responses;
using SchoolManagement.Core.Resources;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Core.Features.User.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                    IRequestHandler<GetUsersPaginationQuery, PaginatedResult<GetUsersPaginationResponse>>,
                                    IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, UserManager<ApplicationUser> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PaginatedResult<GetUsersPaginationResponse>> Handle(GetUsersPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var usersPaginatedList = await _mapper.ProjectTo<GetUsersPaginationResponse>(users).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return usersPaginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return NotFound<GetUserByIdResponse>();

            var userMapper = _mapper.Map<GetUserByIdResponse>(user);
            return Success(userMapper);
        }
    }
}
