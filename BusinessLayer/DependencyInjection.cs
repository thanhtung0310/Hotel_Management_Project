using BusinessLayer.IService;
using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DependencyInjection
    {
        public static void InjectService(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmpInfoService, EmpInfoService>();
            services.AddScoped<ICusInfoService, CusInfoService>();
            services.AddScoped<IRoomInfoService, RoomInfoService>();
            services.AddScoped<ICusByNumInfoService, CusByNumInfoService>();
            services.AddScoped<IRoomByNumInfoService, RoomByNumInfoService>();
            services.AddScoped<IRoomStatusInfoService, RoomStatusInfoService>();
            services.AddScoped<IBookedCusInfoService, BookedCusInfoService>();
            services.AddScoped<IBookedRoomInfoService, BookedRoomInfoService>();
        }
    }
}
