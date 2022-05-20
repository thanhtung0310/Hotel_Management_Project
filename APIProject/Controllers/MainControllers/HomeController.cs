using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Entity;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using BusinessLayer.Extentions;
using BCryptNet = BCrypt.Net.BCrypt;
using APIProject.Data;
using CommonData = APIProject.Data.CommonConstants;

namespace APIProject.Controllers
{
  public class HomeController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    const string SessionUsername = "_username";
    const string SessionRole = "_role";
    const string SessionName = "_name";
    const string Session = "_session";
    UserSessionInfo UserInfo = new UserSessionInfo();

    private readonly ILogger<HomeController> _logger;

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = CommonData.USER_USERNAME;
      ViewBag.SessionRole = CommonData.USER_ROLE;
      ViewBag.SessionName = CommonData.USER_NAME;
    }

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      GetSessionInfo();

      return View();
    }

    public IActionResult Privacy()
    {
      GetSessionInfo();

      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      GetSessionInfo();

      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public ActionResult Login()
    {
      return View();
    }

    public IActionResult Logout()
    {
      GetSessionInfo();

      ViewBag.Message = "You have signed out successfully! You will be redirected to Login page.";
      HttpContext.Session.Clear();
      return View();
    }


    // POST: Login
    [HttpPost]
    public async Task<IActionResult> Login(UserSession user)
    {
      int costParam = 13;
      string hashPassword = BCryptNet.HashPassword(user.acc_password, costParam);

      UserSession loggedInUser = new UserSession();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
        using (var response = await httpClient.PostAsync(baseUrl + "/user_sessions/login", content))
        //https://localhost:44304/api/user_sessions/login
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            loggedInUser = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

            // verify input password with db_password
            bool verified = BCryptNet.Verify(user.acc_password, loggedInUser.acc_password);

            if (loggedInUser != null || verified)
            {
              // set session Info
              HttpContext.Session.SetObjectAsJson("UserInfo", loggedInUser);
              HttpContext.Session.SetString(SessionUsername, loggedInUser.acc_username);
              HttpContext.Session.SetString(SessionRole, loggedInUser.acc_role);
              HttpContext.Session.SetString(SessionName, loggedInUser.acc_name);
              //HttpContext.Session.SetString(Session, loggedInUser.acc_session);

              // keep common constants
              CommonData.USER_SESSION = HttpContext.Session.GetString(Session);
              CommonData.USER_NAME = HttpContext.Session.GetString(SessionName);
              CommonData.USER_ROLE = HttpContext.Session.GetString(SessionRole);
              CommonData.USER_USERNAME = HttpContext.Session.GetString(SessionUsername);

              //Response.Cookies["login"] = userSession.acc_session;


              //TempData["Username"] = user.acc_username;
              //TempData["userInfo"] = loggedInUser;
              ViewBag.StatusCode = "Success";
            }
            else
            {
              ViewBag.StatusCode = response.StatusCode;
              ViewBag.Message = "Log in process failed! Please try again!";
              return View();
            }
          }
          else
          {
            ViewBag.StatusCode = response.StatusCode;
            ViewBag.Message = "Log in process failed! Please try again!";
            return View();
          }
        }
      }
      return RedirectToAction("Index");
    }

    public ViewResult ChangeInformation()
    {
      GetSessionInfo();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangeInformation(string acc_username, UserSession newData)
    {
      //acc_username = TempData["SessionUsername"];
      newData = ViewBag.Session;
      UserSession receivedData = new UserSession();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(newData), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PutAsync(baseUrl + "/user_sessions/" + acc_username, content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedData = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedData);
    }
  }
}
