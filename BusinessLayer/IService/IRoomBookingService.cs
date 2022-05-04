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
        Task<Response<room_booking>> BookRoom(room_booking room, int booking_type);
    }
}
