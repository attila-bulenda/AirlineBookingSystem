using AirlineBookingSystem.Users.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Infrastructure.Configurations
{
    public class UserSeedingConfiguration
    {    
        public static async Task SeedAsync(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure roles exist
            var roles = new[] { "User", "Administrator" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Seed users
            var users = new List<(string Email, string FirstName, string LastName, string Role)>
            {
                // 10 Users
                ("user1@example.com", "Alice", "Smith", "User"),
                ("user2@example.com", "Bob", "Johnson", "User"),
                ("user3@example.com", "Charlie", "Williams", "User"),
                ("user4@example.com", "Diana", "Brown", "User"),
                ("user5@example.com", "Ethan", "Jones", "User"),
                ("user6@example.com", "Fiona", "Garcia", "User"),
                ("user7@example.com", "George", "Martinez", "User"),
                ("user8@example.com", "Hannah", "Davis", "User"),
                ("user9@example.com", "Ian", "Rodriguez", "User"),
                ("user10@example.com", "Julia", "Lopez", "User"),

                // 2 Admins
                ("admin1@example.com", "Admin", "One", "Administrator"),
                ("admin2@example.com", "Admin", "Two", "Administrator")
            };

            const string defaultPassword = "Pa$$w0rd!";

            foreach (var (email, firstName, lastName, role) in users)
            {
                if (await userManager.FindByEmailAsync(email) is not null)
                    continue;

                var user = new SystemUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, defaultPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    // Log or throw for debugging
                    throw new Exception($"Failed to create user {email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
    
}
