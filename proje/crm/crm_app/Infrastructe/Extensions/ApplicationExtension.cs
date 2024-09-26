using Microsoft.AspNetCore.Identity;

namespace crm_app.Infrastructe.Extensions
{
    public static class ApplicationExtension
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "admin123.";

            //UserManager
            UserManager<IdentityUser> userManager = app
            .ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            //RoleManager
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
            .CreateAsyncScope().ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "admin@gmail.com",
                    PhoneNumber = "053466484",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("admin user could not created");

                var roleResult = await userManager.AddToRolesAsync(user,
                      roleManager
                          .Roles
                          .Select(r => r.Name)
                       .ToList()
                  );
                if (!roleResult.Succeeded)
                    throw new Exception("system have problems with role defination for admin");
            }

        }
    
        
    }

}