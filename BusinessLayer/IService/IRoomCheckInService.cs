using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IRoomCheckInService
    {
        Task<Response<room_info>> CheckInRoom(int room_type_id);
    }
}
