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

    public async Task<Response<room_booking>> CheckOutUnpaidRoom(int room_id, room_booking room)
    {
      var response = new Response<room_booking>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@room_id", room_id)
            .AddParam("@check_out_date", room.check_out_date)
            .AddParam("@payment_type_id", room.payment_type_id)
            .AddParam("@payment_amount", room.payment_amount);
        var roomCheckedOut = await _provider.QueryFirstOrDefaultAsync<room_booking>("room_checking_out", param, commandType: CommandType.StoredProcedure);
        response.Data = roomCheckedOut;
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

    public async Task<Response<room_booking>> CheckOutPaidRoom(int room_id, room_booking room)
    {
      var response = new Response<room_booking>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@room_id", room_id)
            .AddParam("@check_out_date", room.check_out_date);
        var roomCheckedOut = await _provider.QueryFirstOrDefaultAsync<room_booking>("vip_room_checking_out", param, commandType: CommandType.StoredProcedure);
        response.Data = roomCheckedOut;
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
