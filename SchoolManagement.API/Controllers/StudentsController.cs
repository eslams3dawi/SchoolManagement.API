using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Data.AppMetaData;

namespace SchoolManagement.Controllers
{
    [ApiController]
    public class StudentsController : AppController
    {
        public StudentsController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudents()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> GetStudentsPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Router.StudentRouting.Update)]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
