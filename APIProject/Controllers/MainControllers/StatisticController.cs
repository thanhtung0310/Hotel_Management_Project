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
using CommonData = APIProject.Data.CommonConstants;

namespace APIProject.Controllers.MainControllers
{
  public class StatisticController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = CommonData.USER_USERNAME;
      ViewBag.SessionRole = CommonData.USER_ROLE;
      ViewBag.SessionName = CommonData.USER_NAME;
    }

    public IActionResult Index()
    {
      GetSessionInfo();
      return View();
    }

    // GET: StatisticController/GetCustomerTraffic
    public async Task<IActionResult> GetCustomerTraffic()
    {
      GetSessionInfo();

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
      GetSessionInfo();

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
      GetSessionInfo();

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

    public ViewResult GetOrderNumBetweenDates()
    {
      GetSessionInfo();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetOrderNumBetweenDates(order_number_statistic inputNum)
    {
      GetSessionInfo();

      order_number_statistic orderNum = new order_number_statistic();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(inputNum), Encoding.UTF8, "application/json");
        using (var response = await httpClient.PostAsync(baseUrl + "/statistics/order_dates", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            orderNum = JsonConvert.DeserializeObject<order_number_statistic>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(orderNum);
    }

    public ViewResult GetOrderNumInMonth()
    {
      GetSessionInfo();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetOrderNumInMonth(single_order_number_statistic inputNum)
    {
      GetSessionInfo();

      order_number_statistic orderNum = new order_number_statistic();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(inputNum), Encoding.UTF8, "application/json");
        using (var response = await httpClient.PostAsync(baseUrl + "/statistics/order_month", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            orderNum = JsonConvert.DeserializeObject<order_number_statistic>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(orderNum);
    }

    public ViewResult GetOrderNumInYear()
    {
      GetSessionInfo();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetOrderNumInYear(single_order_number_statistic inputNum)
    {
      GetSessionInfo();

      single_order_number_statistic orderNum = new single_order_number_statistic();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(inputNum), Encoding.UTF8, "application/json");
        using (var response = await httpClient.PostAsync(baseUrl + "/statistics/order_year", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            orderNum = JsonConvert.DeserializeObject<single_order_number_statistic>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(orderNum);
    }
  }

}
