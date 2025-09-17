using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        private readonly DbSet<Instructor> _instructors;
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _instructors = dbContext.Set<Instructor>();
        }
    }
}
