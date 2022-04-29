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
using BusinessLayer.Extentions;

namespace BusinessLayer.Service
{
    public class RoomInfoService: BaseController<room_info>, IRoomInfoService
    {
        private readonly IDbConnection _provider;
        public RoomInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<List<room_info>>> GetRoomList()
        {
            var response = new Response<List<room_info>>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                var roomInfo = await _provider.QueryAsync<room_info>("room_info_get", commandType: CommandType.StoredProcedure);
                response.Data = roomInfo.AsList();
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<Response<List<room_info>>> GetRoomByID(int id)
        {
            var response = new Response<List<room_info>>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@type", id);
                var roomInfo = await _provider.QueryAsync<room_info>("available_room_info_by_type_get", param, commandType: CommandType.StoredProcedure);
                response.Data = roomInfo.AsList();
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
