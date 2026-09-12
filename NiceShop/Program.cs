using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NiceShop.Filters;
using NiceShop.Models;
using NiceShop.services;

namespace NiceShop;

using Microsoft.Data.SqlClient;
using NiceShop.Data;

public class Program {
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var baseConnection = builder.Configuration.GetConnectionString("DefaultConnection");
        var connectionBuilder = new SqlConnectionStringBuilder(baseConnection);
        var dbServer = builder.Configuration["DbServer"];
        var dbUser = builder.Configuration["DbUser"];
        var dbPassword = builder.Configuration["DbPassword"];
        if (!string.IsNullOrEmpty(dbServer)){
            connectionBuilder.IntegratedSecurity = false;
            connectionBuilder.DataSource = dbServer;
            connectionBuilder.UserID = dbUser;
            connectionBuilder.Password = dbPassword;
            connectionBuilder.Encrypt = false;
            connectionBuilder.TrustServerCertificate = true;
        }

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionBuilder.ConnectionString));
        // Add services to the container.
        builder.Services.AddControllersWithViews(opt => { opt.Filters.Add<HandelErrorAttribute>(); }
        );
 
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddScoped<AdminDefualtService>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()){
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    
            // The roles you want in your system
            string[] roleNames = ["Admin"];

            foreach (var roleName in roleNames)
            {
                // Check if the role already exists in the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create it if it doesn't exist
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminService = scope.ServiceProvider.GetRequiredService<AdminDefualtService>();
            await adminService.createAdmin();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        await app.RunAsync();
    }
}