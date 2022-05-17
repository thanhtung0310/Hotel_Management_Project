using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.IService;
using Entity;

namespace APIProject.Controllers.CustomControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class statisticsController : ControllerBase
  {
    private readonly IStatisticService _statisticService;
    public statisticsController(IStatisticService statisticService)
    {
      _statisticService = statisticService;
    }

    /// <summary>
    /// Get number of orders between dates
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    // GET api/<statisticsController>/order_dates/?date1={}?date2={}
    [HttpGet("order_dates/{date1}-{date2}")]
    public async Task<Response<order_number_statistic>> GetOrderNumBetweenDates(DateTime date1, DateTime date2)
    {
      return await _statisticService.GetOrderNumBetweenDates(date1, date2);
    }

    /// <summary>
    /// Get number of orders in month/year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    // GET api/<statisticsController>/order_month/{}
    [HttpGet("order_month/{date}")]
    public async Task<Response<order_number_statistic>> GetOrderNumInMonth(DateTime date)
    {
      return await _statisticService.GetOrderNumInMonth(date);
    }

    /// <summary>
    /// Get number of orders between dates
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    // GET api/<statisticsController>/order_year/{}
    [HttpGet("order_year/{date}")]
    public async Task<Response<single_order_number_statistic>> GetOrderNumInYear(DateTime date)
    {
      return await _statisticService.GetOrderNumInYear(date);
    }

    /// <summary>
    /// Get customer traffic
    /// </summary>
    /// <returns></returns>
    // GET api/<statisticsController>/customer_traffic
    [HttpGet("customer_traffic")]
    public async Task<Response<List<cus_traffic_statistic>>> GetCustomerTraffic()
    {
      return await _statisticService.GetCustomerTraffic();
    }

    /// <summary>
    /// Get most popular room type
    /// </summary>
    /// <returns></returns>
    // GET api/<statisticsController>/most_popular_room_type
    [HttpGet("most_popular_room_type")]
    public async Task<Response<List<room_popular_statistic>>> GetMostPopularRoomType()
    {
      return await _statisticService.GetMostPopularRoomType();
    }

    /// <summary>
    /// Get least popular room type
    /// </summary>
    /// <returns></returns>
    // GET api/<statisticsController>/least_popular_room_type
    [HttpGet("least_popular_room_type")]
    public async Task<Response<List<room_popular_statistic>>> GetLeastPopularRoomType()
    {
      return await _statisticService.GetLeastPopularRoomType();
    }
  }
}
