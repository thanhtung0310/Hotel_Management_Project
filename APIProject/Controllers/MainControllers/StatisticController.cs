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
using APIProject.Data;

namespace APIProject.Controllers.MainControllers
{
  public class StatisticController : Controller
  {
    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";

    string baseUrl = StaticVar.baseUrl;

    private void GetSessionInfo()
    {
      // passing user data
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    // GET: StatisticController
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
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cusList = StaticVar.GetData<List<cus_traffic_statistic>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // GET: StatisticController/GetTotalCountType
    public async Task<IActionResult> GetTotalCountType()
    {
      GetSessionInfo();

      List<room_type_count_statistic> totalList = new List<room_type_count_statistic>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/total_room_type"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            totalList = StaticVar.GetData<List<room_type_count_statistic>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(totalList);
    }

    // GET: StatisticController/GetAvailCountType
    public async Task<IActionResult> GetAvailCountType()
    {
      GetSessionInfo();

      List<room_type_count_statistic> totalList = new List<room_type_count_statistic>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/avail_room_type"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            totalList = StaticVar.GetData<List<room_type_count_statistic>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
      }
    }
      return View(totalList);
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
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            roomList = StaticVar.GetData<List<room_popular_statistic>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
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
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            roomList = StaticVar.GetData<List<room_popular_statistic>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    // GET: StatisticController/GetOrderNumBetweenDates
    public ViewResult GetOrderNumBetweenDates()
    {
      GetSessionInfo();

      return View();
    }

    // GET: StatisticController/GetOrderNumBetweenDates
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

            orderNum = StaticVar.GetData<order_number_statistic>(apiResponse);

            if (orderNum == null)
            {
              ViewBag.Message = "There are no data between such dates! Please try again!";
            }
            else
            {
              ViewBag.StatusCode = "Success";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(orderNum);
    }

    // GET: StatisticController/GetOrderNumInMonth
    public ViewResult GetOrderNumInMonth()
    {
      GetSessionInfo();

      return View();
    }

    // POST: StatisticController/GetOrderNumInMonth
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

            orderNum = StaticVar.GetData<order_number_statistic>(apiResponse);

            if (orderNum == null)
            {
              ViewBag.Message = "There are no data in that month of year! Please try again!";
            }
            else
            {
              ViewBag.StatusCode = "Success";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(orderNum);
    }

    // GET: StatisticController/GetOrderNumInYear
    public ViewResult GetOrderNumInYear()
    {
      GetSessionInfo();

      return View();
    }

    // POST: StatisticController/GetOrderNumInYear
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

            orderNum = StaticVar.GetData<single_order_number_statistic>(apiResponse);

            if (orderNum == null)
            {
              ViewBag.Message = "There are no data in that year! Please try again!";
            }
            else
            {
              ViewBag.StatusCode = "Success";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(orderNum);
    }
  }
}
