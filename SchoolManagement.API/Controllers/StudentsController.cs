using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Return a list of students without pagination", OperationId = "GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet(Router.StudentRouting.Paginated)]
        [SwaggerOperation(Summary = "Return a paginated list of students", OperationId = "GetStudentsPaginated")]
        public async Task<IActionResult> GetStudentsPaginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet(Router.StudentRouting.GetById)]
        [SwaggerOperation(Summary = "Return a specific student by his ID", OperationId = "GetStudentById")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Router.StudentRouting.Create)]
        [SwaggerOperation(Summary = "Create a student account instead of student registration", OperationId = "AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Router.StudentRouting.Update)]
        [SwaggerOperation(Summary = "Edit student's data", OperationId = "UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand student)
        {
            var response = await _mediator.Send(student);
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.StudentRouting.Delete)]
        [SwaggerOperation(Summary = "Remove student by his ID", OperationId = "DeleteStudent")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
