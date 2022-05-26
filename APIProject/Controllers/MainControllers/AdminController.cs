using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers.MainControllers
{
  public class AdminController : Controller
  {
    // manage identity
    private UserManager<UserSession> userManager;

    public AdminController(UserManager<UserSession> usrMgr)
    {
      userManager = usrMgr;
    }
    public IActionResult Index()
    {
      return View();
    }
  }
}
