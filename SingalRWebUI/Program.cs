using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SingalR.DataAccessLayer.Concrete;
using SingalR.EntityLayer.Entities;

namespace SingalRWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

            builder.Services.AddDbContext<SingalRContext>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SingalRContext>();
            builder.Services.AddHttpClient();

            // Add services to the container.
            builder.Services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
            });

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Login/Index";
            });

            var app = builder.Build();

            app.UseStatusCodePages(async statuscode =>
            {
                if (statuscode.HttpContext.Response.StatusCode == 404)
                {
                    statuscode.HttpContext.Response.Redirect("/Error/NotFound404Page/");
                }
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
