using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IRoomBookingService
  {
    Task<Response<room_booking>> BookUnpaid(room_booking room);
    Task<Response<room_booking>> BookPaid(room_booking room);
  }
}
