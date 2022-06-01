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
    Task<Response<List<checked_cus_info>>> GetCheckedinCusList();
    Task<Response<cus_info>> GetCustomerByID(int id);
    Task<Response<cus_info>> GetID();
    Task<Response<cus_info>> CreateCustomer(cus_info cus);
    Task<Response<cus_info>> UpdateCustomer(cus_info cus);
    Task<Response<cus_info>> DeleteCustomerByID(int id);
    Task<Response<List<booked_cus_info>>> GetBookedCustomerList();
    Task<Response<booked_cus_info>> GetBookedCustomerByNum(string num);
    Task<Response<cus_info>> GetCustomerByNum(string num);
  }
}
