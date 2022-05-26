using BusinessLayer.IService;
using Dapper;
using Entity;
using DatabaseProvider;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Extentions;
using System.Data.Common;

namespace BusinessLayer.Service
{
  public class StatisticService: BaseController<cus_traffic_statistic>, BaseController<order_number_statistic>, BaseController<room_popular_statistic>, IStatisticService
  {
    private readonly IDbConnection _provider;
    public StatisticService(IDbConnection provider)
    {
      _provider = provider;
    }
    
    public async Task<Response<List<cus_traffic_statistic>>> GetCustomerTraffic()
    {
      var response = new Response<List<cus_traffic_statistic>>();
      try
      {
        _provider.Open();
          var cusList = await _provider.QueryAsync<cus_traffic_statistic>("customer_and_time_info_get", null, commandType: CommandType.StoredProcedure);
          response.Data = cusList.AsList();
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

    public async Task<Response<List<room_type_count_statistic>>> GetTotalCountType()
    {
      var response = new Response<List<room_type_count_statistic>>();
      try
      {
        _provider.Open();
        var cusList = await _provider.QueryAsync<room_type_count_statistic>("total_num_room_type_list_get", null, commandType: CommandType.StoredProcedure);
        response.Data = cusList.AsList();
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

    public async Task<Response<List<room_type_count_statistic>>> GetAvailCountType()
    {
      var response = new Response<List<room_type_count_statistic>>();
      try
      {
        _provider.Open();
        var cusList = await _provider.QueryAsync<room_type_count_statistic>("avail_num_room_type_list_get", null, commandType: CommandType.StoredProcedure);
        response.Data = cusList.AsList();
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

    public async Task<Response<order_number_statistic>> GetOrderNumBetweenDates(order_number_statistic inputNum)
    {
      var response = new Response<order_number_statistic>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@date1", inputNum.date1)
            .AddParam("@date2", inputNum.date2);
        var orderNum = await _provider.QueryFirstOrDefaultAsync<order_number_statistic>("order_num_between_dates_get", param, commandType: CommandType.StoredProcedure);
        response.Data = orderNum;
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

    public async Task<Response<order_number_statistic>> GetOrderNumInMonth(single_order_number_statistic inputNum)
    {
      var response = new Response<order_number_statistic>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@date", inputNum.date);
        var orderNum = await _provider.QueryFirstOrDefaultAsync<order_number_statistic>("order_num_in_month_get", param, commandType: CommandType.StoredProcedure);
        response.Data = orderNum;
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

    public async Task<Response<single_order_number_statistic>> GetOrderNumInYear(single_order_number_statistic inputNum)
    {
      var response = new Response<single_order_number_statistic>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@date", inputNum.date);
        var orderNum = await _provider.QueryFirstOrDefaultAsync<single_order_number_statistic>("order_num_in_year_get", param, commandType: CommandType.StoredProcedure);
        response.Data = orderNum;
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

    public async Task<Response<List<room_popular_statistic>>> GetMostPopularRoomType()
    {
      var response = new Response<List<room_popular_statistic>>();
      try
      {
        _provider.Open();
        var roomList = await _provider.QueryAsync<room_popular_statistic>("most_popular_room_type_get", null, commandType: CommandType.StoredProcedure);
        response.Data = roomList.AsList();
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

    public async Task<Response<List<room_popular_statistic>>> GetLeastPopularRoomType()
    {
      var response = new Response<List<room_popular_statistic>>();
      try
      {
        _provider.Open();
        var roomList = await _provider.QueryAsync<room_popular_statistic>("least_popular_room_type_get", null, commandType: CommandType.StoredProcedure);
        response.Data = roomList.AsList();
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
