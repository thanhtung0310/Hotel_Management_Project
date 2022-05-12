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

namespace APIProject.Controllers.MyCustomForm
{
  public class Room_InfoController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    // GET: Room_InfoController
    public async Task<IActionResult> Index()
    {
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
    public async Task<IActionResult> GetRoomBookedByTypeID(int id)
    {
      List<room_info> roomList = new List<room_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/booked_room_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            roomList = JsonConvert.DeserializeObject<List<room_info>>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(roomList);
    }

    public ViewResult GetRoomByTypeID() => View();
    // Post: Room_InfoController/Details/5
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

    public ViewResult GetRoomByNum() => View();
    // Post: Room_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetRoomByNum(string num)
    {
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
    
    public ViewResult GetRoomByStatus() => View();
    // Post: Room_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetRoomByStatus(int id)
    {
      room_status_info room = new room_status_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/room_status_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            room = JsonConvert.DeserializeObject<room_status_info>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(room);
    }

    // GET: Cus_InfoController/Delete/5
    [HttpPost]
    public async Task<IActionResult> DeleteCustomer(int num)
    {
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
