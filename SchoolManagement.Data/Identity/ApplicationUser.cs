using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
