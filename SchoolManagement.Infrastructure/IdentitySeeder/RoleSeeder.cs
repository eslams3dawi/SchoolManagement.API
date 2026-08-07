using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Infrastructure.IdentitySeeder
{
    public static class RoleSeeder
    {
        public async static Task SeedAsync(RoleManager<IdentityRole> _roleManager)
        {
            var rolesCount = _roleManager.Roles.Count();
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Name = "Student"
                },
                new IdentityRole
                {
                    Name = "Instructor"
                },
                new IdentityRole
                {
                    Name = "User"
                }
            };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name))
                    await _roleManager.CreateAsync(role);
            }
        }
    }
}
