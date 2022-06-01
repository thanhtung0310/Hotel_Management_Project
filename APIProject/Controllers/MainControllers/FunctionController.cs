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
  public class FunctionController : Controller
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

    // GET: FunctionController/BookRoom
    public async Task<IActionResult> BookRoom()
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

    // POST: FunctionController/BookUnpaidRoomResult
    [HttpPost]
    public async Task<IActionResult> BookUnpaidRoomResult(room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedRoom = new room_booking();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room_Booking), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/function/booking/1", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            receivedRoom = StaticVar.GetData<room_booking>(apiResponse);

            if (receivedRoom == null)
            {
              ViewBag.Message = "Booking process failed! Please try again!";
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
      return View(receivedRoom);
    }

    // POST: FunctionController/BookPaidRoomResult
    [HttpPost]
    public async Task<IActionResult> BookPaidRoomResult(room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedRoom = new room_booking();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room_Booking), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/function/booking/2", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            receivedRoom = StaticVar.GetData<room_booking>(apiResponse);

            if (receivedRoom == null)
            {
              ViewBag.Message = "Booking process failed! Please try again!";
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
      return View(receivedRoom);
    }

    // GET: FunctionController/CheckIn
    public async Task<IActionResult> CheckIn()
    {
      GetSessionInfo();

      List<booked_cus_info> cusList = new List<booked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/booked"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cusList = StaticVar.GetData<List<booked_cus_info>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // POST: FunctionController/CheckInResult
    [HttpPost]
    public async Task<IActionResult> CheckInResult(input_check_data input)
    {
      GetSessionInfo();

      room_check_in room = new room_check_in();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/function/check_in", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            room = StaticVar.GetData<room_check_in>(apiResponse);

            if (room == null)
            {
              ViewBag.Message = "Check-in process failed! Please try again!";
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
      return View(room);
    }

    // GET: FunctionController/CheckOut
    public async Task<IActionResult> CheckOut()
    {
      GetSessionInfo();

      List<checked_cus_info> cusList = new List<checked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/checked_in"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cusList = StaticVar.GetData<List<checked_cus_info>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // POST: FunctionController/CheckOutUnpaidRoomResult
    [HttpPost]
    public async Task<IActionResult> CheckOutUnpaidRoomResult(room_check_out room)
    {
      GetSessionInfo();

      room_check_out receivedRoom = new room_check_out();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/function/check_out/1", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            receivedRoom = StaticVar.GetData<room_check_out>(apiResponse);

            if (receivedRoom == null)
            {
              ViewBag.Message = "Check-out process failed! Please try again!";
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
      return View(receivedRoom);
    }

    // POST: FunctionController/CheckOutPaidRoomResult
    [HttpPost]
    public async Task<IActionResult> CheckOutPaidRoomResult(room_check_out room)
    {
      GetSessionInfo();

      room_check_out receivedRoom = new room_check_out();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/function/check_out/2", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            receivedRoom = StaticVar.GetData<room_check_out>(apiResponse);

            if (receivedRoom == null)
            {
              ViewBag.Message = "Check-out process failed! Please try again!";
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
      return View(receivedRoom);
    }

    // GET: FunctionController/ConvertVacantRoom
    public async Task<IActionResult> ConvertVacantRoom()
    {
      GetSessionInfo();

      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/function/vacant_convert"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            ViewBag.Message = "You have converted all checked-out rooms to vacant status successfully!";
            ViewBag.StatusCode = "Success";
          }
          else
          {
            ViewBag.Message = "Convert to vacant room process failed! Please try again!";
            ViewBag.StatusCode = response.StatusCode;
          }
        }
      }
      return View();
    }

    // GET: FunctionController/ConvertSingleVacantRoom
    public ActionResult ConvertSingleVacantRoom()
    {
      GetSessionInfo();

      return View();
    }

    // POST: FunctionController/ConvertSingleVacantRoom
    [HttpPost]
    public async Task<IActionResult> ConvertSingleVacantRoom(int id)
    {
      GetSessionInfo();

      room_info room = new room_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/function/vacant_convert/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            room = StaticVar.GetData<room_info>(apiResponse);

            if (room == null)
            {
              ViewBag.Message = "Convert to vacant room process failed! Please try again!";
              return View();
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
      return View(room);
    }

  }
}
