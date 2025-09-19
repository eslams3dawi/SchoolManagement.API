using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
