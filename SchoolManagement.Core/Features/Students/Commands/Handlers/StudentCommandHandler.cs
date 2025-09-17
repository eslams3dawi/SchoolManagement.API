using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<AddStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddStudentAsync(studentMapper);

            Response<string> response;
            if (result == "Created")
                response = Created<string>();
            else
                response = BadRequest<string>();

            response.Meta = new { Count = _studentService.GetStudentsQueryable().Count() };
            return response;
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.StudentId);

            if (student == null)
                return NotFound<string>();

            var studentMapper = _mapper.Map(request, student);
            var result = await _studentService.EditStudentAsync(studentMapper);

            if (result == "Updated")
                return Updated<string>();

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.StudentId);

            if (student == null)
                return NotFound<string>();

            var result = await _studentService.DeleteStudentAsync(student);

            if (result == "Deleted")
                return Deleted<string>();

            return BadRequest<string>();
        }
    }
}
