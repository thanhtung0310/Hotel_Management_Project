using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entity;
using System.Net.Http.Headers;

namespace MyForm.Controllers
{
  public class customer_informationController : Controller
  {
    //Hosted web API REST Service base url
    string Baseurl = "http://localhost:5000/";
    public async Task<ActionResult> Index()
    {
      List<cus_info> CusInfo = new List<cus_info>();
      using (var client = new HttpClient())
      {
        //Passing service base url
        client.BaseAddress = new Uri(Baseurl);
        client.DefaultRequestHeaders.Clear();
        //Define request data format
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        HttpResponseMessage Res = await client.GetAsync("api/cus_infos/GetCustomerList");
        //Checking the response is successful or not which is sent using HttpClient
        if (Res.IsSuccessStatusCode)
        {
          //Storing the response details recieved from web api
          var CusResponse = Res.Content.ReadAsStringAsync().Result;
          //Deserializing the response recieved from web api and storing into the Employee list
          CusInfo = JsonConvert.DeserializeObject<List<cus_info>>(CusResponse);
        }
        //returning the employee list to view
        return View(CusInfo);
      }

      //public IActionResult Index()
      //{
      //  return View();
    }
  }
}
