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
using BCryptNet = BCrypt.Net.BCrypt;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace APIProject.Controllers.MainControllers
{
  public class FunctionController : BaseController
  {
    readonly string baseUrl = StaticVar.baseUrl;

    // GET: FunctionController/Logout
    public async Task<IActionResult> Logout(string acc_username)
    {
      acc_username = HttpContext.Session.GetString("SessionUsername");

      UserSession user = new UserSession();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/user_sessions/logout/" + acc_username))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            user = StaticVar.GetData<UserSession>(apiResponse);

            ViewBag.StatusCode = "Success";
            ViewBag.Message = "You have signed out successfully! You will be redirected to Login page.";
            ClearSessionInfo();
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View();
    }

    // GET: FunctionController/ChangeInformation
    public async Task<IActionResult> ChangeInformation(string acc_username)
    {
      acc_username = HttpContext.Session.GetString("SessionUsername");

      UserSession user = new UserSession();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/user_sessions/" + acc_username))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            user = StaticVar.GetData<UserSession>(apiResponse);

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(user);
    }

    // POST: FunctionController/ChangeInformation
    [HttpPost]
    public async Task<IActionResult> ChangeInformation(UserSession newData)
    {
      UserSession receivedData = new UserSession();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(newData), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PutAsync(baseUrl + "/user_sessions/info", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            receivedData = StaticVar.GetData<UserSession>(apiResponse);

            SetSessionInfo(receivedData);

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedData);
    }

    // GET: FunctionController/ChangePassword
    public async Task<IActionResult> ChangePassword(string acc_username)
    {
      acc_username = HttpContext.Session.GetString("SessionUsername");

      UserSession user = new UserSession();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/user_sessions/" + acc_username))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            user = StaticVar.GetData<UserSession>(apiResponse);

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(user);
    }

    // POST: FunctionController/ChangePassword
    [HttpPost]
    public async Task<IActionResult> ChangePassword(string acc_username, string acc_old_password, string acc_new_password, string acc_new_password2)
    {
      acc_username = HttpContext.Session.GetString("SessionUsername");

      //// check mật khẩu cũ
      UserSession checkUser = new UserSession();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/user_sessions/" + acc_username))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            checkUser = StaticVar.GetData<UserSession>(apiResponse);

            // verify mật khẩu cũ vừa nhập với mkhau trong db
            bool verified = BCryptNet.Verify(acc_old_password, checkUser.acc_password);

            if (checkUser != null && verified && acc_new_password != acc_old_password && acc_new_password2 == acc_new_password)
            {
              UserSession receivedData = new UserSession();

              // check điều kiện password thành công
              /// mật khẩu cũ đúng với mkhau trong db
              /// mật khẩu mới nhập 2 lần giống nhau
              /// mật khẩu mới khác mật khẩu cũ
              // thành công thì hash password mới rồi lưu lại

              receivedData.acc_username = acc_username;
              receivedData.acc_password = StaticVar.HashedPassword(acc_new_password);

              StringContent content = new StringContent(JsonConvert.SerializeObject(receivedData), Encoding.UTF8, "application/json");

              using (var response2 = await httpClient.PutAsync(baseUrl + "/user_sessions/pwd/", content))
              {
                if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                  var apiResponse2 = await response2.Content.ReadAsStringAsync();

                  receivedData = StaticVar.GetData<UserSession>(apiResponse2);

                  ViewBag.StatusCode = "Success";
                  ViewBag.PwdChangeSuccessMessage = "You have changed your password successfully! Please return to Login page and Login again!";

                  return RedirectToAction("Logout");
                }
                else
                {
                  ViewBag.StatusCode = response.StatusCode;
                  ViewBag.Message = "Changing password process failed! Please try again!";
                  return View();
                }
              }
            }
            else
            {
              ViewBag.StatusCode = response.StatusCode;
              ViewBag.Message = "Changing password process failed! Please try again!";
              return View();
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View();
    }

    // GET: FunctionController/BookRoom
    public async Task<IActionResult> BookRoom()
    {
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

    // POST: FunctionController/CancelBooking
    [HttpPost]
    public async Task<IActionResult> CancelBooking(int reservation_id)
    {
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.DeleteAsync(baseUrl + "/function/cancel/" + reservation_id))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
        }
      }
      return RedirectToAction("CheckIn");
    }

    // GET: FunctionController/CheckIn
    public async Task<IActionResult> CheckIn()
    {
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

    [Admin]
    // GET: FunctionController/ConvertSingleVacantRoom
    public ActionResult ConvertSingleVacantRoom()
    {
      return View();
    }

    // POST: FunctionController/ConvertSingleVacantRoom
    [HttpPost]
    public async Task<IActionResult> ConvertSingleVacantRoom(int id)
    {
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
