using System;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Middleware;
using WebApplicationMVC.Models;
using WebApplicationMVC.Repositories;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<BlogContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
        );
        builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        builder.Services.AddScoped<IRequestRepository, RequestRepository>();


        builder.Services.AddControllersWithViews();

        var app = builder.Build();


        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseMiddleware<LoggingMiddleware>();
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
        
