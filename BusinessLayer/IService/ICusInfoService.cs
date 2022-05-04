using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface ICusInfoService
    {
        Task<Response<List<cus_info>>> GetCustomerList();
        Task<Response<cus_info>> GetCustomerByID(int id);
        Task<Response<cus_info>> CreateCustomer(cus_info cus);
        Task<Response<cus_info>> DeleteCustomerByID(int id);
    }
}
