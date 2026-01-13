using SchoolManagement.Data.Identity;

namespace SchoolManagement.Service.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<ApplicationUser> GetCurrentUser();
        public string GetCurrentUserId();
        public Task<List<string>> GetCurrentUserRoles(ApplicationUser user);
    }
}
