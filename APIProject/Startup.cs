using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using System.Data;
using Microsoft.Data.SqlClient;
using BusinessLayer;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace APIProject
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers(); //APIController

      //services.AddDistributedMemoryCache(); // use memory cache

      // use sql server to save session info
      services.AddDistributedSqlServerCache((options) =>
      {
        options.ConnectionString = "data source=localhost;initial catalog=VMO_HotelManagement;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        options.SchemaName = "dbo";
        options.TableName = "userSessions";
      });

      // session settings
      services.AddSession((options) =>
      {
        options.IdleTimeout = new TimeSpan(12, 0, 0);
        options.Cookie.IsEssential = true;
        options.Cookie.HttpOnly = true;
      });

      // add model-view-controller model
      services.AddMvc((options) =>
      {
        options.EnableEndpointRouting = false;
      });

      // add swagger ui to show api lists
      services.AddSwaggerGen((options) =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProject", Version = "v1" });
      });

      // add database context
      services.AddDbContext<APIProjectContext>((options) =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("APIProjectContext"));
      });

      // use sql connection string in singleton
      services.AddSingleton<IDbConnection>(db => new SqlConnection(
              Configuration.GetConnectionString("APIProjectContext")));

      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //options.CheckConsentNeeded = context => true;
        options.CheckConsentNeeded = context => false;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      DependencyInjection.InjectService(services);

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIProject v1"));
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseCookiePolicy();

      app.UseSession(); //SessionMiddleware - cookie

      app.UseMvcWithDefaultRoute(); //MVC

      app.UseStaticFiles(); //StaticFiles

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseAuthentication();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
