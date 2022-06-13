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
    Task<Response<List<booked_room_info>>> GetBookedRoomList();
    Task<Response<List<booked_room_info>>> GetBookedRoomByType(int room_type_id);
    Task<Response<room_info>> GetRoomByNum(int num);
    Task<Response<List<room_status_info>>> GetRoomByStatusID(int id);
  }
}
