using SchoolManagement.Data.Identity;

namespace SchoolManagement.Infrastructure.Interfaces
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
