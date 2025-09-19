using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.User.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
