using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IEmpInfoService
    {
        Task<Response<List<employee>>> GetEmployeeList();
        Task<Response<employee>> GetEmployeeByID(int id);
    }
}
