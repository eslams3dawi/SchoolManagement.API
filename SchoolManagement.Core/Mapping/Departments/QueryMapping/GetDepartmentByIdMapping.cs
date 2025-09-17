using SchoolManagement.Core.Features.Department.Queries.Response;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))

                .ForMember(dest => dest.InstructorManagerName,
                    opt => opt.MapFrom(src =>
                        src.Localize(src.Manager.FirstNameAr, src.Manager.FirstName) + " " + src.Localize(src.Manager.LastNameAr, src.Manager.LastName)))

                //.ForMember(dest => dest.StudentsList, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.SubjectsList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            //CreateMap<Student, StudentResponse>()
            //.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Localize(src.FirstNameAr, src.FirstNameEn) + " " + src.Localize(src.LastNameAr, src.LastNameEn)));

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Localize(src.FirstNameAr, src.FirstName) + " " + src.Localize(src.LastNameAr, src.LastName)));
        }
    }
}
