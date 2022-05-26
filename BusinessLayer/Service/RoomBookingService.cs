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

    public async Task<Response<room_booking>> BookUnpaid(room_booking room)
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
        await _provider.QueryFirstOrDefaultAsync<room_booking>("room_booking", param, commandType: CommandType.StoredProcedure);
        response.Data = room;
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

    public async Task<Response<room_booking>> BookPaid(room_booking room)
    {
      var response = new Response<room_booking>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@cus_id", room.customer_id)
            .AddParam("@check_in_date", room.expected_check_in_date)
            .AddParam("@day", room.day_stay_number)
            .AddParam("@room_type_id", room.room_type_id)
            .AddParam("@payment_type_id", room.payment_type_id)
            .AddParam("@payment_amount", room.payment_amount)
            .AddParam("@payment_date", room.payment_date);
        await _provider.QueryFirstOrDefaultAsync<room_booking>("vip_room_booking", param, commandType: CommandType.StoredProcedure);
        response.Data = room;
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
