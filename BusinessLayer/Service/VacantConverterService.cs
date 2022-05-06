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
    public class VacantConverterService: BaseController<room_info>, IVacantConverterService
    {
        private readonly IDbConnection _provider;
        public VacantConverterService(IDbConnection provider)
        {
            _provider = provider;
        }
        
        public async Task<Response<room_info>> SingleRoomConvert(int id)
        {
            var response = new Response<room_info>();
            try
            {
                var roomInfo = await _provider.QueryFirstOrDefaultAsync<room_info>("single_room_vacant_convert", id, commandType: CommandType.StoredProcedure);
                response.Data = roomInfo;
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
        public async Task<Response<room_info>> RoomConvert()
        {
            var response = new Response<room_info>();
            try
            {
                var roomInfo = await _provider.QueryFirstOrDefaultAsync<room_info>("room_vacant_convert", null, commandType: CommandType.StoredProcedure);
                response.Data = roomInfo;
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
