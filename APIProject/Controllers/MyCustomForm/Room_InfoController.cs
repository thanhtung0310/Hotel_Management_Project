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

namespace APIProject.Controllers.MyCustomForm
{
  public class Room_InfoController : Controller
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

    // GET: Room_InfoController/Index
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      List<room_info> roomList = new List<room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            roomList = StaticVar.GetData<List<room_info>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    // GET: Room_InfoController/GetBookedRoom
    public async Task<IActionResult> GetBookedRoom()
    {
      GetSessionInfo();

      List<booked_room_info> roomList = new List<booked_room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos/booked"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            roomList = StaticVar.GetData<List<booked_room_info>>(apiResponse);

            if (roomList == null)
            {
              ViewBag.Message = "There are no booked rooms!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    // GET: Room_InfoController/GetBookedRoomByTypeID
    public ViewResult GetBookedRoomByTypeID()
    {
      GetSessionInfo();

      return View();
    }

    // POST: Room_InfoController/GetBookedRoomByTypeID
    [HttpPost]
    public async Task<IActionResult> GetBookedRoomByTypeID(int id)
    {
      GetSessionInfo();

      List<booked_room_info> roomList = new List<booked_room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos/booked/type/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            roomList = StaticVar.GetData<List<booked_room_info>>(apiResponse);
            
            if (roomList == null)
            {
              ViewBag.Message = "There are no rooms available of that type! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    // GET: Room_InfoController/GetRoomByTypeID
    public ViewResult GetRoomByTypeID()
    {
      GetSessionInfo();

      return View();
    }

    // POST: Room_InfoController/GetRoomByTypeID
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

            room = StaticVar.GetData<List<room_info>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(room);
    }

    // GET: Room_InfoController/GetRoomByNum
    public ViewResult GetRoomByNum()
    {
      GetSessionInfo();

      return View();
    }

    // POST: Room_InfoController/GetRoomByNum
    [HttpPost]
    public async Task<IActionResult> GetRoomByNum(string num)
    {
      GetSessionInfo();

      room_info room = new room_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos/num/" + num))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            room = StaticVar.GetData<room_info>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(room);
    }

    // GET: Room_InfoController/GetRoomByStatus
    public ViewResult GetRoomByStatus()
    {
      GetSessionInfo();

      return View();
    }

    // POST: Room_InfoController/GetRoomByStatus
    [HttpPost]
    public async Task<IActionResult> GetRoomByStatus(int id)
    {
      GetSessionInfo();

      List<room_status_info> roomList = new List<room_status_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_infos/status/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            roomList = StaticVar.GetData<List<room_status_info>>(apiResponse);

            if (roomList == null)
            {
              ViewBag.Message = "There are no rooms available with that status! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }
  }
}
