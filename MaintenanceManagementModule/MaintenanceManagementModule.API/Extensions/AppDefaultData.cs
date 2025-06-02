namespace MaintenanceManagementModule.API.Extensions
{
    public static class AppDefaultData
    {
        public static async Task AddAdminAccount(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminEmail = "admin@maintenance.com";
            string adminPassword = "Admin@999";
            string adminRole = "Admin";
            string fullName = "Admin User";

            // Creat admin role
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
                // Admin role created
            }

            // Create an admin user
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var adminUser = new UserEntity
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = fullName,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                    // Admin user created
                }
                else
                {
                    // Failed to create admin user
                }
            }
        }

    }
}
