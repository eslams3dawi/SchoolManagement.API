using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.User.Commands.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
