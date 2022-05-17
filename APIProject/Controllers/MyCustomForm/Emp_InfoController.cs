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
  public class Emp_InfoController : Controller
  {
    public string baseUrl = "https://localhost:44304/api"; //IIS
    //public string baseAddress = "https://localhost:5001/api"; //Kestrel

    // GET: Emp_InfoController
    public async Task<IActionResult> Index()
    {
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

    public ViewResult GetEmployeeByID() => View();
    // Post: Emp_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetEmployeeByID(int id)
    {
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

    public ViewResult GetEmployeeByName() => View();
    // Post: Emp_InfoController/Details/5
    [HttpPost]
    public async Task<IActionResult> GetEmployeeByName(string search_string)
    {
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
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(empList);
    }

    public ViewResult AddEmployee() => View();

    [HttpPost]
    public async Task<IActionResult> AddEmployee(emp_info emp)
    {
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
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedEmp);
    }

    public async Task<IActionResult> Details(int id)
    {
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
