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
        Task<Response<room_check_in>> CheckInRoom(input_check_data input);
    }
}
