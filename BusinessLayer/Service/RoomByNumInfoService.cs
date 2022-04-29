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
    public class RoomByNumInfoService: BaseController<room_info>, IRoomByNumInfoService
    {
        private readonly IDbConnection _provider;
        public RoomByNumInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<room_info>> GetRoomByNum(int num)
        {
            var response = new Response<room_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@num", num);
                var roomInfo = await _provider.QueryAsync<room_info>("room_number_get", param, commandType: CommandType.StoredProcedure);
                response.Data = roomInfo.FirstOrDefault();
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
