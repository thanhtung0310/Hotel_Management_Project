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
using CommonData = APIProject.Data.CommonConstants;

namespace APIProject.Controllers.MyCustomForm
{
  public class Room_InfoController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = CommonData.USER_USERNAME;
      ViewBag.SessionRole = CommonData.USER_ROLE;
      ViewBag.SessionName = CommonData.USER_NAME;
    }

    // GET: Room_InfoController
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      List<room_info> roomList = new List<room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          roomList = JsonConvert.DeserializeObject<List<room_info>>(dataField.ToString());
        }
      }
      return View(roomList);
    }

    // GET: Room_InfoController
    public async Task<IActionResult> GetBookedRoom()
    {
      GetSessionInfo();

      List<room_status_info> roomList = new List<room_status_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_status_infos/0"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            roomList = JsonConvert.DeserializeObject<List<room_status_info>>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    public ViewResult GetBookedRoomByTypeID()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Room_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetBookedRoomByTypeID(int id)
    {
      GetSessionInfo();

      List<booked_room_info> roomList = new List<booked_room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/booked_room_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            roomList = JsonConvert.DeserializeObject<List<booked_room_info>>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    public ViewResult GetRoomByTypeID()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Room_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetRoomByTypeID(int id)
    {
      GetSessionInfo();

      List<room_info> room = new List<room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            room = JsonConvert.DeserializeObject<List<room_info>>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(room);
    }

    public ViewResult GetRoomByNum()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Room_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetRoomByNum(string num)
    {
      GetSessionInfo();

      room_info room = new room_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_by_num_infos/" + num))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            room = JsonConvert.DeserializeObject<room_info>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(room);
    }
    
    public ViewResult GetRoomByStatus()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Room_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetRoomByStatus(int id)
    {
      GetSessionInfo();

      List<room_status_info> roomList = new List<room_status_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_status_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            roomList = JsonConvert.DeserializeObject<List<room_status_info>>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    // GET: Cus_InfoController/Delete/5
    [HttpPost]
    public async Task<IActionResult> ConvertVacantRoom()
    {
      GetSessionInfo();

      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.DeleteAsync(baseUrl + "/vacant/"))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
        }
      }

      return RedirectToAction("Index");
    }

    // GET: Cus_InfoController/Delete/5
    [HttpPost]
    public async Task<IActionResult> DeleteRoom(int num)
    {
      GetSessionInfo();

      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.DeleteAsync(baseUrl + "/room_infos/" + num))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
        }
      }

      return RedirectToAction("Index");
    }
  }
}
