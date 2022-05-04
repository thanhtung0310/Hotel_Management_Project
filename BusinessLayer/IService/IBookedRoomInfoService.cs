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
        Task<Response<booked_room_info>> GetBookedRoomByID(int id);
    }
}
