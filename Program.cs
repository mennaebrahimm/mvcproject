using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcproject.Models;
using mvcproject.Repository;

namespace mvcproject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //session
            builder.Services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //context
            builder.Services.AddDbContext<ProjectContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            //Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
               options =>
               {
                   options.Password.RequireNonAlphanumeric = true;
                   options.Password.RequireLowercase=true;
                   options.Password.RequireUppercase=true;
                   options.Password.RequireDigit = true;
                   options.Password.RequiredLength = 8;
               })
               .AddEntityFrameworkStores<ProjectContext>();

            //Custom Service need to define and register
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();//register
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
