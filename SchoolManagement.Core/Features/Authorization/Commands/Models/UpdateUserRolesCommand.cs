using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Data.Helpers.DTOs;

namespace SchoolManagement.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Response<string>>
    {

    }
}
