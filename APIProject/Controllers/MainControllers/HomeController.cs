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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace APIProject.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;

    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";
    readonly UserSession UserInfo = new UserSession();

    string baseUrl = StaticVar.baseUrl;

    public HomeController(IConfiguration config, ILogger<HomeController> logger)
    {
      _config = config;
      _logger = logger;
    }

    private void GetSessionInfo()
    {
      // passing user data
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    private void SetSessionInfo(UserSession user)
    {
      // set session info
      HttpContext.Session.SetObjectAsJson("UserInfo", user);
      HttpContext.Session.SetString(SessionUsername, user.acc_username);
      HttpContext.Session.SetString(SessionRole, user.acc_role);
      HttpContext.Session.SetString(SessionName, user.acc_name);
      HttpContext.Session.SetString(SessionToken, user.acc_session);
    }

    private void ClearSessionInfo()
    {
      // clear session info
      HttpContext.Session.Clear();
    }


    // GET: HomeController
    public IActionResult Index()
    {
      GetSessionInfo();

      return View();
    }

    // GET: HomeController/Privacy
    public IActionResult Privacy()
    {
      GetSessionInfo();

      return View();
    }

    // GET: HomeController/Terms
    public IActionResult Terms()
    {
      GetSessionInfo();

      return View();
    }

    // GET: HomeController/About
    public IActionResult About()
    {
      GetSessionInfo();

      return View();
    }

    // GET: HomeController/Error
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      GetSessionInfo();

      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // GET: HomeController/Restrict
    public IActionResult Restrict()
    {
      GetSessionInfo();

      return View();
    }

    // GET: HomeController/Login
    public ActionResult Login()
    {
      return View();
    }

    // POST: HomeController/Login
    [HttpPost]
    public async Task<IActionResult> Login(UserSession user)
    {
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

            loggedInUser = StaticVar.GetData<UserSession>(apiResponse);

            if (loggedInUser != null)
            {
              // verify input password with db_password
              bool verified = BCryptNet.Verify(user.acc_password, loggedInUser.acc_password);
              
              if (verified)
              {
                ClearSessionInfo();

                //generate token for first time log in
                loggedInUser.acc_session = GenerateJSONWebToken(loggedInUser);

                StringContent content2 = new StringContent(JsonConvert.SerializeObject(loggedInUser), Encoding.UTF8, "application/json");

                // pass data into acc_session (db) to create acc_session
                using (var response2 = await httpClient.PutAsync(baseUrl + "/user_sessions/start", content2))
                {
                  var apiResponse2 = await response2.Content.ReadAsStringAsync();

                  loggedInUser = StaticVar.GetData<UserSession>(apiResponse2);
                }
                SetSessionInfo(loggedInUser);
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

    private string GenerateJSONWebToken(UserSession user)
    {
      // basic token generate
      var tokenHandler = new JwtSecurityTokenHandler();
      var securityKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("identity_code", user.acc_identity_code.ToString()) }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    private bool ValidateJwtToken(string token)
    {
      if (token == null)
        return false;

      var tokenHandler = new JwtSecurityTokenHandler();
      var securityKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
      try
      {
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(securityKey),
          ValidateIssuer = false,
          ValidateAudience = false,
          // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
          ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        // return true from JWT token if validation successful
        return true;
      }
      catch
      {
        // return false if validation fails
        return false;
      }
    }

    // GET: HomeController/Logout
    public async Task<IActionResult> Logout(string acc_username)
    {
      GetSessionInfo();

      acc_username = HttpContext.Session.GetString(SessionUsername);

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

    // GET: HomeController/ChangeInformation
    public async Task<IActionResult> ChangeInformation(string acc_username)
    {
      GetSessionInfo();

      acc_username = HttpContext.Session.GetString(SessionUsername);

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

    // POST: HomeController/ChangeInformation
    [HttpPost]
    public async Task<IActionResult> ChangeInformation(UserSession newData)
    {
      GetSessionInfo();

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

    // GET: HomeController/ChangePassword
    public async Task<IActionResult> ChangePassword(string acc_username)
    {
      GetSessionInfo();

      acc_username = HttpContext.Session.GetString(SessionUsername);
      
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

    // POST: HomeController/ChangePassword
    [HttpPost]
    public async Task<IActionResult> ChangePassword(string acc_username, string acc_old_password, string acc_new_password, string acc_new_password2)
    {
      GetSessionInfo();

      acc_username = HttpContext.Session.GetString(SessionUsername);

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
  }
}
