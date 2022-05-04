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
        Task<Response<room_info>> CreateRoom(room_info room);
        Task<Response<room_info>> DeleteRoomByID(string num);
    }
}
