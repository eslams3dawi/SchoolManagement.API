using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.Features.Authorization.Queries.Models;
using SchoolManagement.Data.AppMetaData;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppController
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Router.RoleRouting.CreateRole)]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpPost(Router.RoleRouting.AssignRolesToUser)]
        public async Task<IActionResult> AssignRolesToUser([FromBody] AddRolesToUserCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut(Router.RoleRouting.UpdateRole)]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet(Router.RoleRouting.List)]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _mediator.Send(new GetRolesQuery());
            return NewResult(result);
        }

        [HttpGet(Router.RoleRouting.GetById)]
        public async Task<IActionResult> GetRoleById([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery(id));
            return NewResult(result);
        }

        [HttpDelete(Router.RoleRouting.Delete)]
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteRoleCommand(id));
            return NewResult(result);
        }
    }
}
