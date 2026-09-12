using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NiceShop.Filters;
using NiceShop.Models;

namespace NiceShop;

using Microsoft.Data.SqlClient;
using NiceShop.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var baseConnection = builder.Configuration.GetConnectionString("DefaultConnection");
        var connectionBuilder = new SqlConnectionStringBuilder(baseConnection);
        var dbServer = builder.Configuration["DbServer"];
        var dbUser = builder.Configuration["DbUser"];
        var dbPassword = builder.Configuration["DbPassword"];
        if (!string.IsNullOrEmpty(dbServer))
        {
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
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}