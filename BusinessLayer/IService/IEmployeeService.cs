using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IEmployeeService
    {
        Task<Response<List<emp_info>>> GetEmployees();
        string GetEmployeeName(int id);
    }
}
