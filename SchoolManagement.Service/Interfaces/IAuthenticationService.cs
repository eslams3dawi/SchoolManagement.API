using SchoolManagement.Data.Identity;

namespace SchoolManagement.Service.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<string> GenerateJwtToken(ApplicationUser user);
    }
}
