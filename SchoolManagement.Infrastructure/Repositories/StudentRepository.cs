using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _students = context.Set<Student>();
        }
    }
}
