using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace APIProject.Controllers
{
  public static class ControllerExtensions
  {
    public static void LoadViewBag(this ControllerBase controller)
    {
      controller.ViewBag.aaa = "";
    }
  }
}
