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
  public class Cus_InfoController : BaseController
  {
    string baseUrl = StaticVar.baseUrl;

    // GET: Cus_InfoController
    public async Task<IActionResult> Index()
    {
      List<cus_info> cusList = new List<cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cusList = StaticVar.GetData<List<cus_info>>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // GET: Cus_InfoController/GetBookedCustomer
    public async Task<IActionResult> GetBookedCustomer()
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

            if (cusList == null)
            {
              ViewBag.Message = "There are no customers that had booked rooms!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // GET: Cus_InfoController/GetCheckedinCustomer
    public async Task<IActionResult> GetCheckedinCustomer()
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

            if (cusList == null)
            {
              ViewBag.Message = "There are no customers that had checked-in rooms!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // GET: Cus_InfoController/GetCustomerByID
    public ViewResult GetCustomerByID()
    {
      return View();
    }

    // POST: Cus_InfoController/GetCustomerByID
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

            cus = StaticVar.GetData<cus_info>(apiResponse);

            if (cus == null)
            {
              ViewBag.Message = "There are no customers with that ID! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    // GET: Cus_InfoController/GetCustomerByName
    public ViewResult GetCustomerByName()
    {
      return View();
    }

    // POST: Cus_InfoController/GetCustomerByName
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

            cusList = StaticVar.GetData<List<customer>>(apiResponse);

            if (cusList == null)
            {
              ViewBag.Message = "There are no customers with that name! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cusList);
    }

    // GET: Cus_InfoController/GetCustomerByNum
    public ViewResult GetCustomerByNum()
    {
      return View();
    }

    // POST: Cus_InfoController/GetCustomerByNum
    [HttpPost]
    public async Task<IActionResult> GetCustomerByNum(string search_string)
    {
      cus_info cus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/num/" + search_string))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cus = StaticVar.GetData<cus_info>(apiResponse);

            if (cus == null)
            {
              ViewBag.Message = "There are no customers with that number! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    // GET: Cus_InfoController/GetBookedCustomerByNum
    public ViewResult GetBookedCustomerByNum()
    {
      return View();
    }

    // POST: Cus_InfoController/GetBookedCustomerByNum
    [HttpPost]
    public async Task<IActionResult> GetBookedCustomerByNum(string num)
    {
      booked_cus_info cus = new booked_cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/booked/num/" + num))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cus = StaticVar.GetData<booked_cus_info>(apiResponse);

            if (cus == null)
            {
              ViewBag.Message = "There are no booked customers with that number! Please try again!";
            }
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    // GET: Cus_InfoController/AddCustomer
    public async Task<IActionResult> AddCustomer()
    {
      cus_info cus = new cus_info();
      using (var httpClient = new HttpClient())
      {
        using (var response = await httpClient.GetAsync(baseUrl + "/cus_infos/customer_id"))
        {
          if (response.StatusCode == System.Net.HttpStatusCode.OK)
          {
            var apiResponse = await response.Content.ReadAsStringAsync();

            cus = StaticVar.GetData<cus_info>(apiResponse);

            if (cus == null)
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
      return View(cus);
    }

    // POST: Cus_InfoController/AddCustomer
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

            receivedCus = StaticVar.GetData<cus_info>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedCus);
    }

    // GET: Cus_InfoController/Details
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

            cus = StaticVar.GetData<cus_info>(apiResponse);
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(cus);
    }

    // POST: Cus_InfoController/Details
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

            receivedCus = StaticVar.GetData<cus_info>(apiResponse);

            ViewBag.Result = "Success";
          }
          else
            ViewBag.StatusCode = response.StatusCode;
        }
      }
      return View(receivedCus);
    }

    // POST: Cus_InfoController/DeleteCustomer
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
