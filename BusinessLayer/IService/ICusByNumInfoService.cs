using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface ICusByNumInfoService
    {
        Task<Response<cus_info>> GetCustomerByNum(string num);
    }
}
