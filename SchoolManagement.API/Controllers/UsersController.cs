﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Features.User.Queries.Models;
using SchoolManagement.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UsersController : AppController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost(Router.UserRouting.Create)]
        [SwaggerOperation(Summary = "Creates a user account and initialize his role as role by default and send email confirmation code", OperationId = "AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpGet(Router.UserRouting.Paginated)]
        [SwaggerOperation(Summary = "Return a paginated list of users's accounts", OperationId = "GetUsersPagination")]
        public async Task<IActionResult> GetUsersPagination([FromQuery] GetUsersPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Router.UserRouting.GetById)]
        [SwaggerOperation(Summary = "Return a user's account by his ID", OperationId = "GetUserById")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);
        }

        [HttpPut(Router.UserRouting.Update)]
        [SwaggerOperation(Summary = "Edits data of user's account", OperationId = "UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete(Router.UserRouting.Delete)]
        [SwaggerOperation(Summary = "Removes a user's account", OperationId = "DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return NewResult(result);
        }


    }
}
