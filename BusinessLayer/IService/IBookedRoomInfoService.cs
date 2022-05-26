using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IBookedRoomInfoService
  {
    Task<Response<List<booked_room_info>>> GetBookedRoomList();
    Task<Response<List<booked_room_info>>> GetBookedRoomByType(int room_type_id);
  }
}
