using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using GroceryManagementSystem.Data;
using Microsoft.Extensions.FileProviders;

namespace GroceryManagementSystem
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = Configuration.GetConnectionString("DefaultConnection");

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));

      services.AddControllersWithViews();

      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(options =>
          {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
          });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("AdminOnly", policy =>
              {
            policy.RequireRole("Admin");
          });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(
              Path.Combine(env.ContentRootPath, "uploads")),
        RequestPath = "/uploads"
      });

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {

       endpoints.MapControllerRoute(
       name: "groceryDetails",
       pattern: "GroceryItems/Details/{id}",
       defaults: new { controller = "GroceryItems", action = "Details" });


      endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
