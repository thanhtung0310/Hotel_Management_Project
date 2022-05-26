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

    private IConfiguration _config;

    public HomeController(IConfiguration config, ILogger<HomeController> logger)
    {
      _config = config;
      _logger = logger;
    }
    
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";
    UserSession UserInfo = new UserSession();

    private void GetSessionInfo()
    {
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    private void SetSessionInfo(UserSession user)
    {
      // set session Info
      HttpContext.Session.SetObjectAsJson("UserInfo", user);
      HttpContext.Session.SetString(SessionUsername, user.acc_username);
      HttpContext.Session.SetString(SessionRole, user.acc_role);
      HttpContext.Session.SetString(SessionName, user.acc_name);
      HttpContext.Session.SetString(SessionToken, user.acc_session);

      // keep common constants
      CommonData.USER_NAME = HttpContext.Session.GetString(SessionName);
      CommonData.USER_ROLE = HttpContext.Session.GetString(SessionRole);
      CommonData.USER_USERNAME = HttpContext.Session.GetString(SessionUsername);
      CommonData.USER_SESSION_TOKEN = HttpContext.Session.GetString(SessionToken);
      CommonData.USER_INFO = HttpContext.Session.GetObjectFromJson<UserSession>("UserInfo");
    }

    public void ClearSessionInfo()
    {
      HttpContext.Session.Clear();
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

    public IActionResult Terms()
    {
      GetSessionInfo();

      return View();
    }

    public IActionResult About()
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

    private string HashedPassword(string pwd)
    {
      int costParam = 13;
      return BCryptNet.HashPassword(pwd, costParam);
    }

    // POST: Login
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

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            loggedInUser = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

            // verify input password with db_password
            bool verified = BCryptNet.Verify(user.acc_password, loggedInUser.acc_password);

            if (verified)
            {
              ClearSessionInfo();

              if (loggedInUser.acc_session == null)
              {
                //generate token for first time log in
                loggedInUser.acc_session = GenerateJSONWebToken(loggedInUser.acc_identity_code);

                StringContent content2 = new StringContent(JsonConvert.SerializeObject(loggedInUser), Encoding.UTF8, "application/json");

                // pass data into acc_session (db)
                using (var response2 = await httpClient.PutAsync(baseUrl + "/user_sessions/start", content2))
                {
                  var apiResponse2 = await response2.Content.ReadAsStringAsync();

                  JObject jsonArray2 = JObject.Parse(apiResponse2);

                  var dataField2 = jsonArray2["data"];

                  loggedInUser = JsonConvert.DeserializeObject<UserSession>(dataField2.ToString());
                }
              }
              else
              {
                //// check if token is valid -> if not = block
                bool tokenValidated = ValidateJwtToken(loggedInUser.acc_session); 
                if (tokenValidated)
                {
                  StringContent content2 = new StringContent(JsonConvert.SerializeObject(loggedInUser), Encoding.UTF8, "application/json");
                  
                  // pass data into acc_session (db)
                  using (var response2 = await httpClient.PutAsync(baseUrl + "/user_sessions/start", content2))
                  {
                    var apiResponse2 = await response2.Content.ReadAsStringAsync();

                    JObject jsonArray2 = JObject.Parse(apiResponse2);

                    var dataField2 = jsonArray2["data"];

                    loggedInUser = JsonConvert.DeserializeObject<UserSession>(dataField2.ToString());
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
              SetSessionInfo(loggedInUser);
              ViewBag.StatusCode = "Success";

              //// set role
              //IdentityResult res = new IdentityResult();
              //var _role = new IdentityRole();

              //_role.Name = loggedInUser.acc_role;
              //if (!res.Succeeded)
              //{
              //  foreach (IdentityError er in res.Errors)
              //  {
              //    ModelState.AddModelError(string.Empty, er.Description);
              //  }
              //  ViewBag.Message = "Error Adding Role";
              //  return View();
              //}
              //else
              //{
              //  SetSessionInfo(loggedInUser);
              //  ViewBag.StatusCode = "Success";
              //  ViewBag.UserMessage = "Role Added";
              //}
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

    private string GenerateJSONWebToken(int acc_identity_code)
    {
      //// more secure
      //var tokenHandler = new JwtSecurityTokenHandler();
      //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      //var claims = new[]
      //{
      //  new Claim(JwtRegisteredClaimNames.Sub, userInfo.acc_username),
      //  new Claim(JwtRegisteredClaimNames.GivenName, userInfo.acc_name),
      //  new Claim("Role", userInfo.acc_role),
      //  new Claim("Dob", userInfo.acc_dob.ToString("yyyy-MM-dd")),
      //  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      //};

      //var token = new JwtSecurityToken(_config["Jwt:Issuer"],
      //  _config["Jwt:Issuer"],
      //  null,
      //  expires: DateTime.Now.AddMinutes(120), //UtcNow.AddDays(7),
      //  signingCredentials: credentials);

      //return tokenHandler.WriteToken(token);

      // demo
      var tokenHandler = new JwtSecurityTokenHandler();
      var securityKey = Encoding.ASCII.GetBytes("VMO_Hotel_Management_Project");
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("id", acc_identity_code.ToString()) }),
        Expires = DateTime.Now.AddMinutes(120),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }

    private bool ValidateJwtToken(string token)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var securityKey = Encoding.ASCII.GetBytes("VMO_Hotel_Management_Project");
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

        //var jwtToken = (JwtSecurityToken)validatedToken;
        //var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "name").Value);

        // return account id from JWT token if validation successful
        return true;
      }
      catch
      {
        // return null if validation fails
        return false;
      }
    }

    public IActionResult Logout()
    {
      GetSessionInfo();

      ClearSessionInfo();

      ViewBag.Message = "You have signed out successfully! You will be redirected to Login page.";
      return View();
    }

    public async Task<IActionResult> ChangeInformation(string acc_username)
    {
      GetSessionInfo();

      //UserSession user = CommonData.USER_INFO;
      acc_username = HttpContext.Session.GetString(SessionUsername);

      UserSession user = new UserSession();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/user_sessions/" + acc_username))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            user = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(user);
    }

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

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedData = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

            ViewBag.StatusCode = "Success";

            SetSessionInfo(receivedData);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedData);
    }

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

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            user = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

            ViewBag.StatusCode = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(user);
    }

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

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            // thông tin lấy được từ db
            checkUser = JsonConvert.DeserializeObject<UserSession>(dataField.ToString());

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
              receivedData.acc_password = HashedPassword(acc_new_password);

              StringContent content = new StringContent(JsonConvert.SerializeObject(receivedData), Encoding.UTF8, "application/json");

              using (var response2 = await httpClient.PutAsync(baseUrl + "/user_sessions/pwd/", content))
              {
                if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                  var apiResponse2 = await response2.Content.ReadAsStringAsync();

                  JObject jsonArray2 = JObject.Parse(apiResponse2);

                  var dataField2 = jsonArray2["data"];

                  receivedData = JsonConvert.DeserializeObject<UserSession>(dataField2.ToString());

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
