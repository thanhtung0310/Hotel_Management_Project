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
        Task<Response<booked_cus_info>> GetBookedCustomerByNum(string num);
    }
}
