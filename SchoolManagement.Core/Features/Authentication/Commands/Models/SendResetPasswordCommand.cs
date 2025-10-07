using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authentication.Commands.Models
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
