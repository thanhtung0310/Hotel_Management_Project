using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IEmpInfoService
    {
        Task<Response<List<emp_info>>> GetEmployeeList();
        Task<Response<emp_info>> GetEmployeeByID(int? id);
        Task<Response<emp_info>> CreateEmployee(emp_info emp, int id, string name, string username, string pwd, int role_id);
    }
}
