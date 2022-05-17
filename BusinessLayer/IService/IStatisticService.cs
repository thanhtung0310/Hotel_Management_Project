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
    Task<Response<order_number_statistic>> GetOrderNumBetweenDates(DateTime date1, DateTime date2);
    Task<Response<order_number_statistic>> GetOrderNumInMonth(DateTime date);
    Task<Response<single_order_number_statistic>> GetOrderNumInYear(DateTime date);
    Task<Response<List<room_popular_statistic>>> GetMostPopularRoomType();
    Task<Response<List<room_popular_statistic>>> GetLeastPopularRoomType();
  }
}
