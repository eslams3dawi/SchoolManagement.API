using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.User.Commands.Models;
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
    }
}
