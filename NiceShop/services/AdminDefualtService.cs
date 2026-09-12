using Microsoft.AspNetCore.Identity;
using NiceShop.Models;

namespace NiceShop.services;

public class adminDefualtService(UserManager<ApplicationUser> userManager) {
   
    public async Task createAdmin() {
        string adminEmail = "admin@niceshop.com"; 
        string adminPassword = "AdminPassword123!";
        if (await userManager.FindByEmailAsync(adminEmail).ConfigureAwait(false) == null)
        {
            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true // Skips any email confirmation requirements
            };

            var createPowerUser = await userManager.CreateAsync(adminUser, adminPassword);
        
            if (createPowerUser.Succeeded)
            {
                // Assign the user to the Admin role
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}