using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class AssignmentRepository : GenericRepositoryAsync<Assignment>, IAssignmentRepository
    {
        private readonly DbSet<Assignment> _assignments;
        public AssignmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _assignments = dbContext.Set<Assignment>();
        }
    }
}
