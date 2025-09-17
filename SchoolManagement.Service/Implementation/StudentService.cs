using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Infrastructure.Interfaces;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return "Created";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            var transaction = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await transaction.CommitAsync();
                return "Deleted";
            }
            catch
            {
                await transaction.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Updated";
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository
                .GetTableNoTracking()
                .Include(s => s.Department)
                .Where(s => s.StudentId == id)
                .FirstOrDefault();

            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetTableNoTracking().Include(s => s.Department).ToListAsync();
        }
        public async Task<bool> IsPhoneExists(string phone)
        {
            var studentResult = _studentRepository.GetTableNoTracking().Where(s => s.Phone == phone).FirstOrDefault();
            return studentResult != null ? true : false;
        }
        public async Task<bool> IsPhoneExistsExcludeSelf(int id, string phone)
        {
            var studentResult = _studentRepository.GetTableNoTracking().Where(s => s.Phone == phone && s.StudentId != id).FirstOrDefault();
            return studentResult != null ? true : false;
        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableAsTracking().Include(s => s.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum? orderingEnum, string? search)
        {
            var query = _studentRepository.GetTableAsTracking().Include(s => s.Department).AsQueryable();
            if (search != null)
            {
                query = query.Where(s => s.Phone.Contains(search) || s.AddressEn.Contains(search));
            }
            string orderBy;
            if (orderingEnum != null)
            {
                switch (orderingEnum)
                {
                    case StudentOrderingEnum.StudentId:
                        query = query.OrderBy(s => s.StudentId);
                        break;
                    case StudentOrderingEnum.FirstName:
                        query = query.OrderBy(s => s.FirstNameEn);
                        break;
                    case StudentOrderingEnum.LastName:
                        query = query.OrderBy(s => s.LastNameEn);
                        break;
                    case StudentOrderingEnum.Address:
                        query = query.OrderBy(s => s.AddressEn);
                        break;
                    case StudentOrderingEnum.Phone:
                        query = query.OrderBy(s => s.Phone);
                        break;
                    case StudentOrderingEnum.DepartmentName:
                        query = query.OrderBy(s => s.Department.NameEn);
                        break;
                    default:
                        query = query.OrderBy(s => s.StudentId);
                        break;
                }
            }
            return query;
        }

        public IQueryable<Student> GetStudentsByDepartmentQueryable(int departmentId)
        {
            return _studentRepository.GetTableAsTracking().Where(x => x.DepartmentId == departmentId).AsQueryable();
        }
    }
}
