using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IEmployeeService
    {
        Task<List<employee>> GetEmployees();
        string GetEmployeeName(int id);
    }
}
