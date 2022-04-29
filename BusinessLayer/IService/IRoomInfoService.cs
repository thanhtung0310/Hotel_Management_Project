using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IRoomInfoService
    {
        Task<Response<List<room_info>>> GetRoomList();
        Task<Response<List<room_info>>> GetRoomByID(int type);
    }
}
