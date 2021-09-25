using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using WorkWithIdentity.Models;

namespace WorkWithIdentity.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Role.Basic.ToString()));

        }
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "chikki",//U are a SuperAdmin
                Email = "chikki@gmail.com",
                FirstName = "Missb",
                LastName = "dike",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Chikki123#");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Role.SuperAdmin.ToString());
                }

            }
        }
    }
}
