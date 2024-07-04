using System;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Member.API.Helper
{
	public static class SeedUserAdmin
	{

        public static class Permissions
        {
            public const string CreateUser = "permissions.create.user";
            public const string EditUser = "permissions.edit.user";
            // Add other permissions as needed
        }

        public static async Task Initialize(IServiceProvider serviceProvider)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // Ensure the admin role exists
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Check if the admin user exists
            var adminUser = await userManager.FindByEmailAsync("nguyennhat070596@gmail596.com");
            if (adminUser == null)
            {
                // Create the admin user
                adminUser = new IdentityUser
                {
                    UserName = "nhat_nm",
                    Email = "nguyennhat070596@gmail.com",
                };
                var result = await userManager.CreateAsync(adminUser, "Visaothe13_");

                if (result.Succeeded)
                {
                    // Assign the admin role to the user
                    await userManager.AddToRoleAsync(adminUser, "Admin");

                    // Add admin claims
                    await userManager.AddClaimAsync(adminUser, new Claim(ClaimTypes.Role, "Admin"));
                }
            }
        }
    }
}

