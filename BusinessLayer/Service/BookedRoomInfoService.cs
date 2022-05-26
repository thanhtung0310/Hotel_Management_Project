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
  class BookedRoomInfoService : BaseController<booked_room_info>, IBookedRoomInfoService
  {
    private readonly IDbConnection _provider;
    public BookedRoomInfoService(IDbConnection provider) : base()
    {
      _provider = provider;
    }

    public async Task<Response<List<booked_room_info>>> GetBookedRoomList()
    {
      var response = new Response<List<booked_room_info>>();
      try
      {
        _provider.Open();
        var roomInfo = await _provider.QueryAsync<booked_room_info>("reservation_room_list_get", null, commandType: CommandType.StoredProcedure);
        response.Data = roomInfo.AsList();
        response.successResp();
      }
      catch
      {
        response.errorResp();
      }
      finally
      {
        _provider.Close();
      }
      return response;
    }

    public async Task<Response<List<booked_room_info>>> GetBookedRoomByType(int room_type_id)
    {
      var response = new Response<List<booked_room_info>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@room_type_id", room_type_id);
        var roomInfo = await _provider.QueryAsync<booked_room_info>("reservation_room_get", param, commandType: CommandType.StoredProcedure);
        response.Data = roomInfo.AsList();
        response.successResp();
      }
      catch
      {
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