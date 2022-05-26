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

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer((options) =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true, //validate server -> generate token
            ValidateAudience = true, //validate recipient -> token is authorized
            ValidateLifetime = true, //check if token is not expired
            ValidateIssuerSigningKey = true, //check if signing key of the issuer is valid

            // storing values in appsettings.json
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
        });

      //services.AddIdentity<UserSession, IdentityRole>().AddEntityFrameworkStores<APIProjectContext>().AddDefaultTokenProviders();

      services.AddDistributedSqlServerCache((options) =>
      {
        options.ConnectionString = "data source=localhost;initial catalog=VMO_HotelManagement;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        options.SchemaName = "dbo";
        options.TableName = "userSessions";
      });

      services.AddSession((options) =>
      {
        //option.Cookie.Name = "Session_h1kj2h3kj1h23kj";
        options.IdleTimeout = new TimeSpan(24, 0, 0);
        options.Cookie.IsEssential = true;
        options.Cookie.HttpOnly = true;
      });

      services.AddMvc((options) =>
      {
        options.EnableEndpointRouting = false;
      });

      services.AddSwaggerGen((options) =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProject", Version = "v1" });
      });

      services.AddDbContext<APIProjectContext>((options) =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("APIProjectContext"));
      });

      services.AddSingleton<IDbConnection>(db => new SqlConnection(
              Configuration.GetConnectionString("APIProjectContext")));
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
