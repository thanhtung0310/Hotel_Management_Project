using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public ActionResult Login()
    {
      return View();
    }

    // POST: Home
    [HttpPost]
    public ActionResult Logout(string message_value)
    {
      if (message_value == "Yes")
      {
        ViewBag.Message = "You have signed out successfully! You will be redirected to Login page.";
      }
      else
      {
        ViewBag.Message = "Please continue with your works...";
      }
      return View();
    }
  }
}
