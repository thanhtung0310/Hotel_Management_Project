using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IVacantConverterService
    {
        Task<Response<room_info>> SingleRoomConvert(int id);
        Task<Response<room_info>> RoomConvert();
    }
}
