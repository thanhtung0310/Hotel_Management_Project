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
  public class Room_InfoController : BaseController
  {
    string baseUrl = StaticVar.baseUrl;

    // GET: Room_InfoController/Index
    public async Task<IActionResult> Index()
    {
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
      return View();
    }

    // POST: Room_InfoController/GetBookedRoomByTypeID
    [HttpPost]
    public async Task<IActionResult> GetBookedRoomByTypeID(int id)
    {
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
      return View();
    }

    // POST: Room_InfoController/GetRoomByTypeID
    [HttpPost]
    public async Task<IActionResult> GetRoomByTypeID(int id)
    {
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
      return View();
    }

    // POST: Room_InfoController/GetRoomByNum
    [HttpPost]
    public async Task<IActionResult> GetRoomByNum(string num)
    {
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
      return View();
    }

    // POST: Room_InfoController/GetRoomByStatus
    [HttpPost]
    public async Task<IActionResult> GetRoomByStatus(int id)
    {
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
