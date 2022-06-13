using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IFunctionService
  {
    Task<Response<room_booking>> BookUnpaid(room_booking room);
    Task<Response<room_booking>> BookPaid(room_booking room);
    Task<Response<room_booking>> CancelBooking(int reservation_id);
    Task<Response<room_check_in>> CheckInRoom(input_check_data input);
    Task<Response<room_check_out>> CheckOutUnpaidRoom(room_check_out room);
    Task<Response<room_check_out>> CheckOutPaidRoom(room_check_out room);
    Task<Response<room_info>> SingleRoomConvert(int id);
    Task<Response<room_info>> RoomConvert();
  }
}
