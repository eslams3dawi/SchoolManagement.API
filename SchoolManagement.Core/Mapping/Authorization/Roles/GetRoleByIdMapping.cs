using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Features.Authorization.Queries.Responses;

namespace SchoolManagement.Core.Mapping.Authorization
{
    public partial class AuthorizationMapping : Profile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<IdentityRole, GetRoleByIdResponse>();
        }
    }
}
