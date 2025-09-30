using System.Security.Claims;

namespace SchoolManagement.Data.Helpers
{
    public class ClaimStore
    {
        public List<Claim> Claims = new List<Claim>
        {
            new Claim("Add Student", "false"),
            new Claim("Edit Student", "false"),
            new Claim("Delete Student", "false")
        };
    }
}
