using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Data.Helpers;

namespace SchoolManagement.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
