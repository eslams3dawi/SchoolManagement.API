using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Interfaces;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository
                .GetTableNoTracking()
                .Where(x => x.DepartmentId == id)
                .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                .Include(x => x.Instructors)
                .Include(x => x.Manager)
                .FirstOrDefaultAsync();
            return department;
        }

        public async Task<bool> IsDepartmentIdExists(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.DepartmentId == id);
            return department != null ? true : false;
        }
    }
}
