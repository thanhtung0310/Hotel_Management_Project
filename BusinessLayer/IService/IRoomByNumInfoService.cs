using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IRoomByNumInfoService
    {
        Task<Response<room_info>> GetRoomByNum(int num);
    }
}
