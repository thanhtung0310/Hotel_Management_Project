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
        Task<Response<room_booking>> CheckOutRoom(int id, room_booking room);
    }
}
