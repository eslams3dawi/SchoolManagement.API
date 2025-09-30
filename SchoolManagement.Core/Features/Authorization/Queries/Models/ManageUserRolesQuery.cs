using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Data.Helpers.DTOs;

namespace SchoolManagement.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResponse>>
    {
        public ManageUserRolesQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
