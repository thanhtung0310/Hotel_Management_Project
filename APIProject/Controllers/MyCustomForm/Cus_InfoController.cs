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
using CommonData = APIProject.Data.CommonConstants;
using DatabaseProvider;

namespace APIProject.Controllers.MyCustomForm
{
  public class Cus_InfoController : Controller
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

    // GET: Cus_InfoController
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      List<cus_info> cusList = new List<cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<cus_info>>(dataField.ToString());
        }
      }
      return View(cusList);
    }

    public async Task<IActionResult> GetBookedCustomer()
    {
      GetSessionInfo();

      List<booked_cus_info> cusList = new List<booked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/booked_cus_infos"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<booked_cus_info>>(dataField.ToString());
        }
      }
      return View(cusList);
    }

    public async Task<IActionResult> GetCheckedinCustomer()
    {
      GetSessionInfo();

      List<checked_cus_info> cusList = new List<checked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/checked_in"))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<checked_cus_info>>(dataField.ToString());
        }
      }
      return View(cusList);
    }

    public ViewResult GetCustomerByID()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetCustomerByID(int id)
    {
      GetSessionInfo();

      cus_info cus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            cus = JsonConvert.DeserializeObject<cus_info>(dataField.ToString());

            if (cus == null)
            {
              ViewBag.Message = "There are no customers with that ID!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    public ViewResult GetCustomerByName()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetCustomerByName(string search_string)
    {
      GetSessionInfo();

      List<customer> cusList = new List<customer>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/searches/customer-" + search_string))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            cusList = JsonConvert.DeserializeObject<List<customer>>(dataField.ToString());

            if (cusList == null)
            {
              ViewBag.Message = "There are no customers with that name!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    public ViewResult GetCustomerByNum()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetCustomerByNum(string search_string)
    {
      GetSessionInfo();

      cus_info cus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_by_num_infos/" + search_string))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            cus = JsonConvert.DeserializeObject<cus_info>(dataField.ToString());

            if (cus == null)
            {
              ViewBag.Message = "There are no customers with that number";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    public ViewResult GetBookedCustomerByNum()
    {
      GetSessionInfo();

      return View();
    }
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetBookedCustomerByNum(string num)
    {
      GetSessionInfo();

      List<booked_cus_info> cus = new List<booked_cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/booked_cus_infos/" + num))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            cus = JsonConvert.DeserializeObject<List<booked_cus_info>>(dataField.ToString());

            if (cus == null)
            {
              ViewBag.Message = "There are no booked customers with that number!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    public async Task<IActionResult> AddCustomer()
    {
      GetSessionInfo();

      cus_info cus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/customer_id"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            cus = JsonConvert.DeserializeObject<cus_info>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(cus_info cus)
    {
      GetSessionInfo();

      cus_info receivedCus = new cus_info();
      using (var httpClient = new HttpClient())
      {        
        StringContent content = new StringContent(JsonConvert.SerializeObject(cus), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/cus_infos", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedCus = JsonConvert.DeserializeObject<cus_info>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedCus);
    }

    public async Task<IActionResult> Details(int id)
    {
      GetSessionInfo();

      cus_info cus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/" + id))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            cus = JsonConvert.DeserializeObject<cus_info>(dataField.ToString());
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    [HttpPost]
    public async Task<IActionResult> Details(cus_info cus)
    {
      GetSessionInfo();

      cus_info receivedCus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(cus), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PutAsync(baseUrl + "/cus_infos/", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            JObject jsonArray = JObject.Parse(apiResponse);

            var dataField = jsonArray["data"];

            receivedCus = JsonConvert.DeserializeObject<cus_info>(dataField.ToString());

            ViewBag.Result = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedCus);
    }

    // GET: Cus_InfoController/Delete/5
    [HttpPost]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      GetSessionInfo();

      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.DeleteAsync(baseUrl + "/cus_infos/" + id))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
        }
      }

      return RedirectToAction("Index");
    }
  }
}
