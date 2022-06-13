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
using APIProject.Data;

namespace APIProject.Controllers.MyCustomForm
{
  public class Emp_InfoController : BaseController
  {
    string baseUrl = StaticVar.baseUrl;

    // GET: Emp_InfoController
    public async Task<IActionResult> Index()
    {
      List<emp_info> empList = new List<emp_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/emp_infos"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            empList = StaticVar.GetData<List<emp_info>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(empList);
    }

    // GET: Emp_InfoController/GetEmployeeByID
    public ViewResult GetEmployeeByID()
    {
      return View();
    }

    // POST: Emp_InfoController/GetEmployeeByID
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

            emp = StaticVar.GetData<emp_info>(apiResponse);

            if (emp == null)
            {
              ViewBag.Message = "There are no employees with that ID! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(emp);
    }

    // GET: Emp_InfoController/GetEmployeeByName
    public ViewResult GetEmployeeByName()
    {
      return View();
    }

    // GET: Emp_InfoController/GetemployeeByName
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

            empList = StaticVar.GetData<List<employee>>(apiResponse);

            if (empList == null)
            {
              ViewBag.Message = "There are no employees with that name! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(empList);
    }

    [Admin]
    // GET: Emp_InfoController/AddEmployee
    public async Task<IActionResult> AddEmployee()
    {
      emp_info emp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/emp_infos/emp_id"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            emp = StaticVar.GetData<emp_info>(apiResponse);

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

    [Admin]
    // POST: Emp_InfoController/AddEmployee
    [HttpPost]
    public async Task<IActionResult> AddEmployee(emp_info emp)
    {
      // hash input password
      string raw_password = emp.acc_password;
      emp.acc_password = StaticVar.HashedPassword(emp.acc_password);

      emp_info receivedEmp = new emp_info();
      using (var httpClient = new HttpClient())
      {
        StringContent content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(baseUrl + "/emp_infos", content))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            receivedEmp = StaticVar.GetData<emp_info>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedEmp);
    }

    [Admin]
    // GET: Emp_InfoController/Details
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

            emp = StaticVar.GetData<emp_info>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(emp);
    }

    [Admin]
    // POST: Emp_InfoController/Details
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

            receivedEmp = StaticVar.GetData<emp_info>(apiResponse);

            ViewBag.Result = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedEmp);
    }

    [Admin]
    // GET: Emp_InfoController/DeleteEmployee
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
