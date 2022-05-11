using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessLayer.Extentions;

namespace APIProject.Controllers.MyCustomForm
{
  public class Cus_InfoController : Controller
  {
    readonly string baseAddress = "https://localhost:5001/api";
    readonly string controller = "/cus_infos";
    readonly HttpClient client;

    public Cus_InfoController()
    {
      client = new HttpClient();
    }

    // GET: Cus_InfoController
    public async Task<IActionResult> Index()
    {
      Response<cus_info> cusAPI = new Response<cus_info>();
      List<cus_info> cusList = new List<cus_info>();
      using (var httpClient = new HttpClient())
      {
        using (var response = await client.GetAsync(baseAddress + controller))
        {
          var apiResponse = await response.Content.ReadAsStringAsync();

          JObject jsonArray = JObject.Parse(apiResponse);

          var dataField = jsonArray["data"];

          cusList = JsonConvert.DeserializeObject<List<cus_info>>(dataField.ToString());

          //var data = JsonHelper.DeserializeByNewtonsoft<List<cus_info>>(apiResponse);

          //var Data = (cus_info)JsonConvert.DeserializeObject(apiResponse);
        }
      }
      return View(cusList);
    }

    //public ActionResult Index()
    //{
    //  List<cus_info> cusList = new List<cus_info>();
    //  HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/cus_info").Result;
    //  if (response.IsSuccessStatusCode)
    //  {
    //    string data = response.Content.ReadAsStringAsync().Result;
    //    cusList = JsonConvert.DeserializeObject<List<cus_info>>(data);
    //  }

    //  return View(cusList);
    //}

    // GET: Cus_InfoController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: Cus_InfoController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Cus_InfoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Cus_InfoController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Cus_InfoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Cus_InfoController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Cus_InfoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
