using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using DatabaseProvider;

namespace APIProject.Controllers.MainControllers
{
  public class StatisticController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    public IActionResult Index()
    {
      return View();
    }

    // GET: StatisticController/GetCustomerTraffic
    public async Task<IActionResult> GetCustomerTraffic()
    {
      List<cus_traffic_statistic> cusList = new List<cus_traffic_statistic>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/customer_traffic"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<cus_traffic_statistic>>(dataField.ToString());
        }
      }
      return View(cusList);
    }

    // GET: StatisticController/GetMostPopularRoomType
    public async Task<IActionResult> GetMostPopularRoomType()
    {
      List<room_popular_statistic> roomList = new List<room_popular_statistic>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/most_popular_room_type"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          roomList = JsonConvert.DeserializeObject<List<room_popular_statistic>>(dataField.ToString());
        }
      }
      return View(roomList);
    }

    // GET: StatisticController/GetLeastPopularRoomType
    public async Task<IActionResult> GetLeastPopularRoomType()
    {
      List<room_popular_statistic> roomList = new List<room_popular_statistic>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/least_popular_room_type"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          roomList = JsonConvert.DeserializeObject<List<room_popular_statistic>>(dataField.ToString());
        }
      }
      return View(roomList);
    }

    public ViewResult GetOrderNumBetweenDates() => View();

    [HttpPost]
    public async Task<IActionResult> GetOrderNumBetweenDates(DateTime date1, DateTime date2)
    {
      order_number_statistic orderNum = new order_number_statistic();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/order_dates/" + date1 + "-" + date2))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          orderNum = JsonConvert.DeserializeObject<order_number_statistic>(dataField.ToString());
        }
      }
      return View(orderNum);
    }

    public ViewResult GetOrderNumInMonth() => View();

    [HttpPost]
    public async Task<IActionResult> GetOrderNumInMonth(DateTime date)
    {
      order_number_statistic orderNum = new order_number_statistic();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/order_month/" + date))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          orderNum = JsonConvert.DeserializeObject<order_number_statistic>(dataField.ToString());
        }
      }
      return View(orderNum);
    }

    public ViewResult GetOrderNumInYear() => View();

    [HttpPost]
    public async Task<IActionResult> GetOrderNumInYear(DateTime date)
    {
      single_order_number_statistic orderNum = new single_order_number_statistic();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/order_year/" + date))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          orderNum = JsonConvert.DeserializeObject<single_order_number_statistic>(dataField.ToString());
        }
      }
      return View(orderNum);
    }
  }

}
