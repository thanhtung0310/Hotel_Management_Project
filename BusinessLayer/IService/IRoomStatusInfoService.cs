using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IRoomStatusInfoService
    {
        Task<Response<room_status_info>> GetRoomByStatusID(int id);
    }
}
