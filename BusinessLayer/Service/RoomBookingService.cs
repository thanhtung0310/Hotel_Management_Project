using BusinessLayer.Extentions;
using BusinessLayer.IService;
using Dapper;
using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class RoomBookingService : BaseController<room_booking>, IRoomBookingService
    {
        private readonly IDbConnection _provider;
        public RoomBookingService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<room_booking>> BookRoom(room_booking room, int booking_type)
        {
            var response = new Response<room_booking>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@cus_id", room.customer_id)
                    .AddParam("@check_in_date", room.expected_check_in_date)
                    .AddParam("@day", room.day_stay_number)
                    .AddParam("@room_type_id", room.room_type_id);
                if (booking_type == 1)
                {
                    var roomBooked = await _provider.QueryFirstOrDefaultAsync<room_booking>("room_booking", param, commandType: CommandType.StoredProcedure);
                    response.Data = roomBooked;
                    response.successResp();
                }
                else if (booking_type == 2)
                {
                    var roomBooked = await _provider.QueryFirstOrDefaultAsync<room_booking>("vip_room_booking", param, commandType: CommandType.StoredProcedure);
                    response.Data = roomBooked;
                    response.successResp();
                }
                else
                    response.errorResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
    }
}
