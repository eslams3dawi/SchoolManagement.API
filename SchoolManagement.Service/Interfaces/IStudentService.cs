using SchoolManagement.Data.Entities;
using SchoolManagement.Data.Helpers;

namespace SchoolManagement.Service.Interfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddStudentAsync(Student student);
        public Task<bool> IsPhoneExistsExcludeSelf(int id, string phone);
        public Task<bool> IsPhoneExists(string phone);
        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);
        public IQueryable<Student> GetStudentsQueryable();
        public IQueryable<Student> GetStudentsByDepartmentQueryable(int departmentId);
        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum? orderingEnum, string search);
    }
}
