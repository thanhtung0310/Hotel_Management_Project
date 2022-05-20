using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;

namespace APIProject.Controllers
{
  public class UserInfoController : Controller
  {
    const string SessionUsername = "_username";
    const string SessionRole = "_role";
    const string SessionName = "_name";
    const string SessionPwd = "_pwd";
    UserSession UserInfo = new UserSession();

    internal string Username
    {
      get { return ViewBag.SessionUsername; }
      set { ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername); }
    }

    internal string Role
    {
      get { return ViewBag.SessionRole; }
      set { ViewBag.SessionUsername = HttpContext.Session.GetString(SessionRole); }
    }

    internal string Name
    {
      get { return ViewBag.SessionName; }
      set { ViewBag.SessionUsername = HttpContext.Session.GetString(SessionName); }
    }
  }
}
