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
using APIProject.Data;

namespace APIProject.Controllers.MainControllers
{
  public class FunctionController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel
    
    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    public async Task<IActionResult> BookRoom()
    {
      GetSessionInfo();

      List<room_type_count_statistic> totalList = new List<room_type_count_statistic>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/statistics/avail_room_type"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          totalList = JsonConvert.DeserializeObject<List<room_type_count_statistic>>(dataField.ToString());
        }
      }
      return View(totalList);
    }

    [HttpPost]
    public async Task<IActionResult> BookUnpaidRoom(room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedRoom = new room_booking();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room_Booking), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_booking/1", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedRoom = JsonConvert.DeserializeObject<room_booking>(dataField.ToString());

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

    [HttpPost]
    public async Task<IActionResult> BookPaidRoom(room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedRoom = new room_booking();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room_Booking), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_booking/2", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedRoom = JsonConvert.DeserializeObject<room_booking>(dataField.ToString());

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

    public async Task<IActionResult> CheckIn()
    {
      GetSessionInfo();

      List<booked_cus_info> cusList = new List<booked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/booked_cus_infos"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<booked_cus_info>>(dataField.ToString());
        }
      }
      return View(cusList);
    }

    [HttpPost]
    public async Task<IActionResult> CheckInResult(input_check_data input)
    {
      GetSessionInfo();

      room_check_in room = new room_check_in();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_check_in", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            room = JsonConvert.DeserializeObject<room_check_in>(dataField.ToString());

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

    public async Task<IActionResult> CheckOut()
    {
      GetSessionInfo();

      List<checked_cus_info> cusList = new List<checked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/checked_in"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<checked_cus_info>>(dataField.ToString());
        }
      }
      return View(cusList);
    }
    [HttpPost]
    public async Task<IActionResult> CheckOutUnpaidRoom(room_check_out room)
    {
      GetSessionInfo();

      room_check_out receivedRoom = new room_check_out();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_check_out/1", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedRoom = JsonConvert.DeserializeObject<room_check_out>(dataField.ToString());

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

    [HttpPost]
    public async Task<IActionResult> CheckOutPaidRoom(room_check_out room)
    {
      GetSessionInfo();

      room_check_out receivedRoom = new room_check_out();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_check_out/2", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedRoom = JsonConvert.DeserializeObject<room_check_out>(dataField.ToString());

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

    public async Task<IActionResult> ConvertVacantRoom()
    {
      GetSessionInfo();

      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/vacant_converter"))
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

    public ActionResult ConvertSingleVacantRoom()
    {
      GetSessionInfo();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> ConvertSingleVacantRoom(int id)
    {
      GetSessionInfo();

      room_info room = new room_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/vacant_converter/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            room = JsonConvert.DeserializeObject<room_info>(dataField.ToString());
            
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
