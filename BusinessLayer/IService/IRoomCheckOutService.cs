using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IRoomCheckOutService
  {
    Task<Response<room_check_out>> CheckOutUnpaidRoom(room_check_out room);
    Task<Response<room_check_out>> CheckOutPaidRoom(room_check_out room);
  }
}
