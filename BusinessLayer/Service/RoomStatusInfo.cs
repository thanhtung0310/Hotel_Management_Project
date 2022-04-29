using BusinessLayer.IService;
using Dapper;
using Entity;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class RoomStatusInfoService : BaseController<room_status_info>, IRoomStatusInfoService
    {
        private readonly IDbConnection _provider;
        public RoomStatusInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<room_status_info>> GetRoomByStatusID(int id)
        {
            var response = new Response<room_status_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                if (id == 1)
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("vacant_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
                else if (id == 2)
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("unpaid_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
                else if (id == 3)
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("paid_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
                else if (id == 4)
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("in_use_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
                else if (id == 5)
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("need_clean_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
                else if (id == 6)
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("available_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
                else
                {
                    var roomInfo = await _provider.QueryAsync<room_status_info>("booked_room_info_get", commandType: CommandType.StoredProcedure);
                    response.Data = roomInfo.FirstOrDefault();
                }
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
