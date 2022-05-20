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
  public class FunctionController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel
    
    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = CommonData.USER_USERNAME;
      ViewBag.SessionRole = CommonData.USER_ROLE;
      ViewBag.SessionName = CommonData.USER_NAME;
    }

    public ViewResult BookRoom()
    {
      GetSessionInfo();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> BookUnpaidRoom(room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedroom = new room_booking();
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

            receivedroom = JsonConvert.DeserializeObject<room_booking>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedroom);
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

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedRoom);
    }

    public ViewResult CheckIn()
    {
      GetSessionInfo();

      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CheckInResult(int room_type_id)
    {
      GetSessionInfo();

      room_info room = new room_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.PostAsync(baseUrl + "/room_check_in/" + room_type_id, null))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            room = JsonConvert.DeserializeObject<room_info>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(room);
    }

    public ViewResult CheckOut()
    {
      GetSessionInfo();

      return View();
    }
    [HttpPost]
    public async Task<IActionResult> CheckOutUnpaidRoom(int room_id, room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedroom = new room_booking();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room_Booking), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_check_out/1/" + room_id, content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedroom = JsonConvert.DeserializeObject<room_booking>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedroom);
    }

    [HttpPost]
    public async Task<IActionResult> CheckOutPaidRoom(int room_id, room_booking room_Booking)
    {
      GetSessionInfo();

      room_booking receivedRoom = new room_booking();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(room_Booking), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/room_check_out/2/" + room_id, content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedRoom = JsonConvert.DeserializeObject<room_booking>(dataField.ToString());

            ViewBag.StatusCode = "Success";
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
            ViewBag.Message = "You have failed. Please try again!";
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

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(id);
    }

  }
}
