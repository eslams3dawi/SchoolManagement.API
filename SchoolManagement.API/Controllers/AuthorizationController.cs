using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Authorization.Commands.Models;
using SchoolManagement.Core.Features.Authorization.Queries.Models;
using SchoolManagement.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AuthorizationController : AppController
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [SwaggerOperation(Summary = "Create a new role with specified name", OperationId = "CreateRole")]
        [HttpPost(Router.RoleRouting.CreateRole)]
        public async Task<IActionResult> AddRole([FromBody] AddRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Assign one or more role to a specific user", OperationId = "AssignRolesToUser")]
        [HttpPut(Router.RoleRouting.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Edit name of a specific role", OperationId = "UpdateRole")]
        [HttpPut(Router.RoleRouting.UpdateRole)]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Return a list of roles with their names and IDs", OperationId = "GetRoles")]
        [HttpGet(Router.RoleRouting.List)]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _mediator.Send(new GetRolesQuery());
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Return a role name by its ID", OperationId = "GetRoleById")]
        [HttpGet(Router.RoleRouting.GetById)]
        public async Task<IActionResult> GetRoleById([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery(id));
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Remove a specific role by its ID", OperationId = "DeleteRole")]
        [HttpDelete(Router.RoleRouting.Delete)]
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteRoleCommand(id));
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Return list of roles with selected user roles", OperationId = "ManageUserRoles")]
        [HttpGet(Router.RoleRouting.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] string id)
        {
            var result = await _mediator.Send(new ManageUserRolesQuery(id));
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Return list of claims with selected user claims", OperationId = "ManageUserRoles")]
        [HttpGet(Router.ClaimRouting.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] string id)
        {
            var result = await _mediator.Send(new ManageUserClaimsQuery(id));
            return NewResult(result);
        }

        [SwaggerOperation(Summary = "Assign one or more claim to a specific user", OperationId = "AssignClaimsToUser")]
        [HttpPut(Router.ClaimRouting.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
    }
}
