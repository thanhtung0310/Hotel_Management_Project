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
  public class FunctionService : BaseController<room_booking>, IFunctionService
  {
    private readonly IDbConnection _provider;
    public FunctionService(IDbConnection provider) : base()
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

    public async Task<Response<room_booking>> CancelBooking(int reservation_id)
    {
      var response = new Response<room_booking>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@reservation_id", reservation_id);
        var book = await _provider.QueryFirstOrDefaultAsync<room_booking>("cancel_booking", param, commandType: CommandType.StoredProcedure);
        response.Data = book;
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

    public async Task<Response<room_check_in>> CheckInRoom(input_check_data input)
    {
      var response = new Response<room_check_in>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@cus_id", input.customer_id)
          .AddParam("@type", input.room_type_id);
        var roomCheckedIn = await _provider.QueryFirstOrDefaultAsync<room_check_in>("room_checking_in", param, commandType: CommandType.StoredProcedure);
        response.Data = roomCheckedIn;
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

    public async Task<Response<room_check_out>> CheckOutUnpaidRoom(room_check_out room)
    {
      var response = new Response<room_check_out>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@cus_id", room.customer_id)
          .AddParam("@room_id", room.room_id)
          .AddParam("@check_out_date", room.check_out_date)
          .AddParam("@payment_type_id", room.payment_type_id)
          .AddParam("@payment_amount", room.payment_amount);
        var roomCheckedOut = await _provider.QueryFirstOrDefaultAsync<room_check_out>("room_checking_out", param, commandType: CommandType.StoredProcedure);
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

    public async Task<Response<room_check_out>> CheckOutPaidRoom(room_check_out room)
    {
      var response = new Response<room_check_out>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@cus_id", room.customer_id)
          .AddParam("@room_id", room.room_id)
          .AddParam("@check_out_date", room.check_out_date);
        var roomCheckedOut = await _provider.QueryFirstOrDefaultAsync<room_check_out>("vip_room_checking_out", param, commandType: CommandType.StoredProcedure);
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

    public async Task<Response<room_info>> SingleRoomConvert(int id)
    {
      var response = new Response<room_info>();
      try
      {
        DynamicParameters param = new DynamicParameters()
            .AddParam("@room_id", id);
        var roomInfo = await _provider.QueryFirstOrDefaultAsync<room_info>("single_room_vacant_convert", param, commandType: CommandType.StoredProcedure);
        response.Data = roomInfo;
        response.successResp();
      }
      catch (Exception ex)
      {
        response.errorResp();
        throw ex;
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
