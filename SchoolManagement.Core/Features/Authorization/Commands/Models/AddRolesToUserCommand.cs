using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authorization.Commands.Models
{
    public class AddRolesToUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
