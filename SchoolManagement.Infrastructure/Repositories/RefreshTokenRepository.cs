using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Identity;
using SchoolManagement.Infrastructure.Database;
using SchoolManagement.Infrastructure.Interfaces;
namespace SchoolManagement.Infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        private DbSet<UserRefreshToken> _userRefreshToken;
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _userRefreshToken = dbContext.Set<UserRefreshToken>();
        }
    }
}
