using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        private readonly DbSet<Subject> _subjects;
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subjects = dbContext.Set<Subject>();
        }
    }
}
