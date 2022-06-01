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
  public class RoomInfoService : BaseController<room_info>, IRoomInfoService
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

    public async Task<Response<List<room_info>>> GetRoomByID(int id)
    {
      var response = new Response<List<room_info>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@type", id);
        var roomInfo = await _provider.QueryAsync<room_info>("room_info_by_type_get", param, commandType: CommandType.StoredProcedure);
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

    public async Task<Response<room_info>> CreateRoom(room_info room)
    {
      var response = new Response<room_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters();
        var check = _provider.QueryFirstOrDefaultAsync<room_info>("room_number_get", room.room_number, commandType: CommandType.StoredProcedure);
        if (check != null)
        {
          var roomInfo = await _provider.QueryFirstOrDefaultAsync<room_info>("room_info_insert", param, commandType: CommandType.StoredProcedure); // chua co
          response.Data = roomInfo;
          response.successResp();
        }
        else
        {
          response.errorResp();
        }
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

    public async Task<Response<room_info>> DeleteRoomByID(string num)
    {
      var response = new Response<room_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@num", num);
        var check = _provider.QueryFirstOrDefaultAsync<room_info>("room_number_get", num, commandType: CommandType.StoredProcedure);
        if (check != null)
        {
          var roomInfo = await _provider.QueryFirstOrDefaultAsync<room_info>("room_info_delete", param, commandType: CommandType.StoredProcedure);
          response.Data = roomInfo;
          response.successResp();
        }
        else
        {
          response.errorResp();
        }
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

    public async Task<Response<List<room_status_info>>> GetRoomByStatusID(int id)
    {
      var response = new Response<List<room_status_info>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters();
        if (id == 1)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("vacant_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else if (id == 2)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("unpaid_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else if (id == 3)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("paid_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else if (id == 4)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("in_use_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else if (id == 5)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("need_clean_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else if (id == 6)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("available_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else if (id == 0)
        {
          var roomInfo = await _provider.QueryAsync<room_status_info>("booked_room_info_get", commandType: CommandType.StoredProcedure);
          response.Data = roomInfo.AsList();
          response.successResp();
        }
        else
        {
          response.errorResp();
        }
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
