using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Features.User.Queries.Models;
using SchoolManagement.Data.AppMetaData;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    public class UsersController : AppController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return NewResult(result);
        }
        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> GetUsersPagination([FromQuery] GetUsersPaginationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet(Router.UserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return NewResult(result);
        }
    }
}
