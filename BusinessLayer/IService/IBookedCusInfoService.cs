using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IBookedCusInfoService
  {
    Task<Response<List<booked_cus_info>>> GetBookedCustomerList();
    Task<Response<List<booked_cus_info>>> GetBookedCustomerByNum(string num);
  }
}
