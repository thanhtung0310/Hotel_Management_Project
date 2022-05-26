using BusinessLayer.IService;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
  public class DependencyInjection
  {
    public static void InjectService(IServiceCollection services)
    {
      //services.AddScoped<IEmployeeService, EmployeeService>();
      //services.AddScoped<IEmpInfoService, EmpInfoService>();
      //services.AddScoped<ICusInfoService, CusInfoService>();
      //services.AddScoped<IRoomInfoService, RoomInfoService>();
      //services.AddScoped<ICusByNumInfoService, CusByNumInfoService>();
      //services.AddScoped<IRoomByNumInfoService, RoomByNumInfoService>();
      //services.AddScoped<IRoomStatusInfoService, RoomStatusInfoService>();
      //services.AddScoped<IBookedCusInfoService, BookedCusInfoService>();
      //services.AddScoped<IBookedRoomInfoService, BookedRoomInfoService>();
      //services.AddScoped<IRoomBookingService, RoomBookingService>();
      //services.AddScoped<IRoomCheckInService, RoomCheckInService>();
      //services.AddScoped<IRoomCheckOutService, RoomCheckOutService>();
      //services.AddScoped<IVacantConverterService, VacantConverterService>();

      // similar but using Scrutor to inject
      services.Scan(scan => scan
          .FromAssemblyOf<IBookedCusInfoService>()
          .AddClasses(classes => classes.InNamespaces("BusinessLayer"))
          .AsImplementedInterfaces()
          .WithScopedLifetime());

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
  }
}
