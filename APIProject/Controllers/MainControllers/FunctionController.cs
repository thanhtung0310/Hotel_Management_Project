using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers.MainControllers
{
  public class FunctionController : Controller
  {
    public IActionResult BookRoom()
    {
      return View();
    }

    public IActionResult CheckIn()
    {
      return View();
    }

    public IActionResult CheckOut()
    {
      return View();
    }
  }
}
