using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authentication.Queries.Models
{
    public class ResetPasswordQuery : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
