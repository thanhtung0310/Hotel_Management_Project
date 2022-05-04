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
    public class RoomCheckInService : BaseController<room_info>, IRoomCheckInService
    {
        private readonly IDbConnection _provider;
        public RoomCheckInService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<room_info>> CheckInRoom(int room_type_id)
        {
            var response = new Response<room_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@type", room_type_id);
                var roomCheckedIn = await _provider.QueryFirstOrDefaultAsync<room_info>("room_checking_in", param, commandType: CommandType.StoredProcedure);
                response.Data = roomCheckedIn;
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
