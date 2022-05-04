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
    public class RoomCheckOutService : BaseController<room_info>, IRoomCheckOutService
    {
        private readonly IDbConnection _provider;
        public RoomCheckOutService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<room_booking>> CheckOutRoom(int id, room_booking room)
        {
            var response = new Response<room_booking>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@room_id", id)
                    .AddParam("@check_out_date", room.check_out_date);
                var roomCheckedOut = await _provider.QueryFirstOrDefaultAsync<room_booking>("room_checking_out", param, commandType: CommandType.StoredProcedure);
                response.Data = roomCheckedOut;
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
    }
}
