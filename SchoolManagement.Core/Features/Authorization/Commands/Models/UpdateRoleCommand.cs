using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authorization.Commands.Models
{
    public class UpdateRoleCommand : Data.Helpers.DTOs.UpdateRoleCommand, IRequest<Response<string>>
    {

    }
}
