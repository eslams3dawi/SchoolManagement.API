using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Identity;

namespace SchoolManagement.Infrastructure.IdentitySeeder
{
    public static class UserSeeder
    {
        public async static Task SeedAsync(UserManager<ApplicationUser> _userManager)
        {
            var usersCount = _userManager.Users.Count();
            if (usersCount == 0)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@school.com",
                    FirstName = "Admin",
                    LastName = "System",
                    Country = "Egypt",
                    Address = "Giza",
                    PhoneNumber = "01223031577",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(adminUser, "Admin@123");
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
