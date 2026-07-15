using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolManagement.Core.Features.Students.Queries.Handlers;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Core.Mapping.Students;
using SchoolManagement.Core.Resources;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Interfaces;
using System.Net;

namespace SchoolManagement.XUnitTests.CoreTests.Students.Queries
{
    public class StudentQueryHandlerTests
    {
        private readonly Mock<IStudentService> _studentServiceMock;

        private readonly IMapper _mapper;
        private readonly StudentProfile _studentProfile;

        private readonly Mock<IStringLocalizer<SharedResources>> _stringLocalizerMock;
        public StudentQueryHandlerTests()
        {
            _studentServiceMock = new();

            _studentProfile = new();
            var configurations = new MapperConfiguration(c => c.AddProfile(_studentProfile));
            _mapper = new Mapper(configurations);//Then the mapper can map

            _stringLocalizerMock = new();
        }

        [Fact]
        public async Task StudentList_Should_Not_Be_Null_Or_Empty()
        {
            //Arrange
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapper, _stringLocalizerMock.Object);
            var query = new GetStudentListQuery();

            IEnumerable<Student> studentList = new List<Student>()
            {
                new Student{StudentId = 1, FirstNameEn = "Eslam", LastNameEn = "Seadawi", AddressEn = "Giza", DepartmentId = 1, Phone = "01223031977", Department = new Department{ NameEn = "IT"} }
            };
            _studentServiceMock.Setup(x => x.GetStudentsListAsync()).Returns(Task.FromResult(studentList));
            //Means → skip the GetStudentsListAsync method which is in handler and work on this studentList

            //Act
            var result = await handler.Handle(query, default);
            //Assert
            result.Data.Should().NotBeNullOrEmpty();
            result.Succeeded.Should().BeTrue();
        }

        [Theory]
        [InlineData(3)]//not found
        public async Task Handle_StudentById_Should_Return_Not_Found_And_Status_Code_404(int id)
        {
            //Arrange
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapper, _stringLocalizerMock.Object);
            var query = new GetStudentByIdQuery(id);

            var departments = new List<Department>()
            {
                new Department{DepartmentId =1, NameEn = "IT", NameAr = "تكنولوجيا المعلومات"},
                new Department{DepartmentId =2, NameEn = "CS", NameAr = "علوم الحاسب"}
            };

            IEnumerable<Student> studentList = new List<Student>()
            {
                new Student{StudentId = 1, FirstNameEn = "Eslam", LastNameEn = "Seadawi", AddressEn = "Giza", DepartmentId = 1, Phone = "01223031977", Department = departments[0] },
                new Student{StudentId = 2, FirstNameEn = "Khaled", LastNameEn = "Sayed", AddressEn = "Cairo", DepartmentId = 2, Phone = "01223031977", Department = departments[1] }
            };
            _studentServiceMock.Setup(x => x.GetStudentByIdAsync(id)).Returns(Task.FromResult(studentList.SingleOrDefault(s => s.StudentId == id)));

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Succeeded.Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Handle_StudentById_Should_Return_Success_And_Status_Code_200(int id)
        {
            //Arrange
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapper, _stringLocalizerMock.Object);
            var query = new GetStudentByIdQuery(id);

            var departments = new List<Department>()
            {
                new Department{DepartmentId =1, NameEn = "IT", NameAr = "تكنولوجيا المعلومات"},
                new Department{DepartmentId =2, NameEn = "CS", NameAr = "علوم الحاسب"}
            };

            IEnumerable<Student> studentList = new List<Student>()
            {
                new Student{StudentId = 1, FirstNameEn = "Eslam", LastNameEn = "Seadawi", AddressEn = "Giza", DepartmentId = 1, Phone = "01223031977", Department = departments[0] },
                new Student{StudentId = 2, FirstNameEn = "Khaled", LastNameEn = "Sayed", AddressEn = "Cairo", DepartmentId = 2, Phone = "01223031977", Department = departments[1] }
            };
            _studentServiceMock.Setup(x => x.GetStudentByIdAsync(id)).Returns(Task.FromResult(studentList.SingleOrDefault(s => s.StudentId == id)));

            //Act
            var result = await handler.Handle(query, default);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Succeeded.Should().BeTrue();
            result.Data.StudentId.Should().Be(id);
        }
    }
}
