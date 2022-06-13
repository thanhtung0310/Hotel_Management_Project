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
using APIProject.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using BCryptNet = BCrypt.Net.BCrypt;

namespace APIProject.Controllers
{
  public class HomeController : Controller
  {
    readonly string baseUrl = StaticVar.baseUrl;


    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;

    public HomeController(IConfiguration config, ILogger<HomeController> logger)
    {
      _config = config;
      _logger = logger;
    }

    // GET: HomeController
    public IActionResult Index()
    {
      return View();
    }

    // GET: HomeController/Privacy
    public IActionResult Privacy()
    {
      return View();
    }

    // GET: HomeController/Terms
    public IActionResult Terms()
    {
      return View();
    }

    // GET: HomeController/About
    public IActionResult About()
    {
      return View();
    }

    // GET: HomeController/Error
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // GET: HomeController/Restrict
    public IActionResult Restrict()
    {
      return View();
    }

    // GET: HomeController/Blocked
    public IActionResult Blocked()
    {
      return View();
    }

    // GET: HomeController/Login
    public ActionResult Login()
    {
      return View();
    }

    // POST: FunctionController/Login
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
                HttpContext.Session.Clear();

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

    public void SetSessionInfo(UserSession user)
    {
      // set session info
      HttpContext.Session.SetObjectAsJson("UserInfo", user);
      HttpContext.Session.SetString("SessionUsername", user.acc_username);
      HttpContext.Session.SetString("SessionRole", user.acc_role);
      HttpContext.Session.SetString("SessionName", user.acc_name);
      HttpContext.Session.SetString("SessionToken", user.acc_session);
    }
  }
}
