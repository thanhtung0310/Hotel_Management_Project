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
  public class Cus_InfoController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    // GET: Cus_InfoController
    public async Task<IActionResult> Index()
    {
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

    public ViewResult GetCustomerByID() => View();
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetCustomerByID(int id)
    {
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

    public ViewResult GetCustomerByName() => View();
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetCustomerByName(string search_string)
    {
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
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    public ViewResult GetCustomerByNum() => View();
    // Post: Cus_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetCustomerByNum(string search_string)
    {
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
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    public ViewResult AddCustomer() => View();

    [HttpPost]
    public async Task<IActionResult> AddCustomer(cus_info cus)
    {
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
