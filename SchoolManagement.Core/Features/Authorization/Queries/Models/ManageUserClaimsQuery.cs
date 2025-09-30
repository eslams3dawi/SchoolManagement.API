using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Data.Helpers.DTOs;

namespace SchoolManagement.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResponse>>
    {
        public ManageUserClaimsQuery(string userId)
        {
            this.userId = userId;
        }

        public string userId { get; set; }
    }
}
