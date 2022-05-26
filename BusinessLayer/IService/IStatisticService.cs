using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IStatisticService
  {
    Task<Response<List<cus_traffic_statistic>>> GetCustomerTraffic();
    Task<Response<List<room_type_count_statistic>>> GetTotalCountType();
    Task<Response<List<room_type_count_statistic>>> GetAvailCountType();
    Task<Response<order_number_statistic>> GetOrderNumBetweenDates(order_number_statistic inputNum);
    Task<Response<order_number_statistic>> GetOrderNumInMonth(single_order_number_statistic inputNum);
    Task<Response<single_order_number_statistic>> GetOrderNumInYear(single_order_number_statistic inputNum);
    Task<Response<List<room_popular_statistic>>> GetMostPopularRoomType();
    Task<Response<List<room_popular_statistic>>> GetLeastPopularRoomType();
  }
}
