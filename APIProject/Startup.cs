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
      services.AddControllers();
      //services.AddControllersWithViews();
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

      app.UseMvcWithDefaultRoute();

      app.UseStaticFiles();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
