using Microsoft.EntityFrameworkCore;
using NiceShop.Filters;
using NiceShop.Services;

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

        // session setup so guests (not logged in) can have a cart that remembers what they added
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ICartService, CartService>();

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

        app.UseSession(); // must be before UseAuthorization and before controllers use it

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}