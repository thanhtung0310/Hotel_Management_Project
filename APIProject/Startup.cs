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
using Microsoft.AspNetCore.Routing.Constraints;
using System;
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

      services.AddDistributedSqlServerCache((option) =>
      {
        option.ConnectionString = "data source=localhost;initial catalog=VMO_HotelManagement;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        option.SchemaName = "dbo";
        option.TableName = "userSessions";
      });

      services.AddSession((option) =>
      {
        option.Cookie.Name = "Session_h1kj2h3kj1h23kj";
        option.IdleTimeout = new TimeSpan(12, 0, 0);
        option.Cookie.IsEssential = true; 
        option.Cookie.HttpOnly = true;
      });

      //services.AddSession((option) =>
      //{
      //option.Cookie.Name = "StaffSession_f7as2f1f1l12jkl";
      //option.IdleTimeout = new TimeSpan(0, 0, 3);
      //});

      services.AddMvc(options => options.EnableEndpointRouting = false);
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIProject", Version = "v1" });
      });

      services.AddDbContext<APIProjectContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("APIProjectContext")));

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

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");

        //endpoints.MapGet("/readwritesession", async (context) =>
        //{
        //  int? count; // key = count
        //  count = context.Session.GetInt32("count"); // read session

        //  if (count == null)
        //  {
        //    count = 0;
        //  }

        //  count += 1;

        //  context.Session.SetInt32("count", count.Value); // write session
        //  //context.Session.SetString() = json { }

        //  await context.Response.WriteAsync($"So lan truy cap /readwritesession la: {count}");

        //});
      });
    }
  }
}
