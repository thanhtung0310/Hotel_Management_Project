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
using BCryptNet = BCrypt.Net.BCrypt;
using CommonData = APIProject.Data.CommonConstants;

namespace APIProject.Controllers.MyCustomForm
{
  public class Emp_InfoController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    // GET: Emp_InfoController
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      List<emp_info> empList = new List<emp_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/emp_infos"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          empList = JsonConvert.DeserializeObject<List<emp_info>>(dataField.ToString());
        }
      }
      return View(empList);
    }

    public ViewResult GetEmployeeByID()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Emp_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetEmployeeByID(int id)
    {
      GetSessionInfo();

      emp_info emp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/emp_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            emp = JsonConvert.DeserializeObject<emp_info>(dataField.ToString());
            if (emp == null)
            {
              ViewBag.Message = "There are no employees with that ID!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(emp);
    }

    public ViewResult GetEmployeeByName()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Emp_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetEmployeeByName(string search_string)
    {
      GetSessionInfo();

      List<employee> empList = new List<employee>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/searches/employee-" + search_string))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            empList = JsonConvert.DeserializeObject<List<employee>>(dataField.ToString());

            if (empList == null)
            {
              ViewBag.Message = "There are no employees with that name!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(empList);
    }

    public async Task<IActionResult> AddEmployee()
    {
      GetSessionInfo();

      emp_info emp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/emp_infos/emp_id"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            emp = JsonConvert.DeserializeObject<emp_info>(dataField.ToString());

            if (emp == null)
            {
              return View();
            }
            else
            {
              ViewBag.Message = "Please continue with your work!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(emp);
    }

    public string HashedPassword(string pwd)
    {
      int costParam = 13;
      return BCryptNet.HashPassword(pwd, costParam);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(emp_info emp)
    {
      GetSessionInfo();

      // hash input password
      string raw_password = emp.acc_password;
      emp.acc_password = HashedPassword(emp.acc_password);

      emp_info receivedEmp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/emp_infos", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedEmp = JsonConvert.DeserializeObject<emp_info>(dataField.ToString());

            if (receivedEmp == null)
            {
              return View();
            }
            else
            {
              //// create role in identity
              //string role_name = "";
              //if (receivedEmp.role_id == 1)
              //  role_name = "Admin";
              //else if (receivedEmp.role_id == 2)
              //  role_name = "";

              //UserSession user = new UserSession
              //{
              //  acc_username = receivedEmp.acc_username,
              //  acc_name = receivedEmp.emp_name,
              //  acc_contact_number = receivedEmp.emp_contact_number,
              //  acc_role = receivedEmp.role_name,
              //}
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedEmp);
    }

    public async Task<IActionResult> Details(int id)
    {
      GetSessionInfo();

      emp_info emp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/emp_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            emp = JsonConvert.DeserializeObject<emp_info>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(emp);
    }

    [HttpPost]
    public async Task<IActionResult> Details(emp_info emp)
    {
      GetSessionInfo();

      emp_info receivedEmp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PutAsync(baseUrl + "/emp_infos/", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedEmp = JsonConvert.DeserializeObject<emp_info>(dataField.ToString());

            ViewBag.Result = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedEmp);
    }

    // GET: Emp_InfoController/Delete/5
    [HttpPost]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
      GetSessionInfo();

      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.DeleteAsync(baseUrl + "/emp_infos/" + id))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
        }
      }
      return RedirectToAction("Index");
    }
  }
}
