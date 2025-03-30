using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaulKA.Data;

namespace PaulKA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Register ApplicationDbContext for dependency injection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use SQL Server

            var app = builder.Build();

            // Configure middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // Handle exceptions in production
                app.UseHsts(); // Enforce HTTPS with HSTS
            }

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
            app.UseStaticFiles(); // Serve static files from wwwroot folder

            app.UseRouting(); // Enable routing middleware
            app.UseAuthentication(); // Enable authentication middleware (if applicable)
            app.UseAuthorization(); // Enable authorization middleware (if applicable)

            // Configure default route for MVC
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route: Home/Index

            // Map Razor Pages (optional, if Razor Pages are used)
            app.MapRazorPages();

            // Run the application
            app.Run();
        }
    }
}
