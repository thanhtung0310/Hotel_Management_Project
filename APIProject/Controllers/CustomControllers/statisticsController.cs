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
    /// <param name="inputNum"></param>
    /// <returns></returns>
    // POST api/<statisticsController>/order_dates
    [HttpPost("order_dates")]
    public async Task<Response<order_number_statistic>> GetOrderNumBetweenDates(order_number_statistic inputNum)
    {
      return await _statisticService.GetOrderNumBetweenDates(inputNum);
    }

    /// <summary>
    /// Get number of orders in month/year
    /// </summary>
    /// <param name="inputNum"></param>
    /// <returns></returns>
    // POST api/<statisticsController>/order_month
    [HttpPost("order_month")]
    public async Task<Response<order_number_statistic>> GetOrderNumInMonth(single_order_number_statistic inputNum)
    {
      return await _statisticService.GetOrderNumInMonth(inputNum);
    }

    /// <summary>
    /// Get number of orders between dates
    /// </summary>
    /// <param name="inputNum"></param>
    /// <returns></returns>
    // POST api/<statisticsController>/order_year
    [HttpPost("order_year")]
    public async Task<Response<single_order_number_statistic>> GetOrderNumInYear(single_order_number_statistic inputNum)
    {
      return await _statisticService.GetOrderNumInYear(inputNum);
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
    /// Get total number by room type
    /// </summary>
    /// <returns></returns>
    // GET api/<statisticsController>/customer_traffic
    [HttpGet("total_room_type")]
    public async Task<Response<List<room_type_count_statistic>>> GetTotalCountType()
    {
      return await _statisticService.GetTotalCountType();
    }

    /// <summary>
    /// Get total number of available room by room type
    /// </summary>
    /// <returns></returns>
    // GET api/<statisticsController>/customer_traffic
    [HttpGet("avail_room_type")]
    public async Task<Response<List<room_type_count_statistic>>> GetAvailCountType()
    {
      return await _statisticService.GetAvailCountType();
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
