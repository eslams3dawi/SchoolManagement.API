using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public DeleteRoleCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
