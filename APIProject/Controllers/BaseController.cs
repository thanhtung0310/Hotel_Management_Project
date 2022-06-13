using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using BusinessLayer.Extentions;
using APIProject.Data;

namespace APIProject.Controllers
{
  [User]
  public class BaseController: Controller
  {
    protected string sessionUsername, sessionRole, sessionName, sessionToken;

    public void GetSessionInfo()
    {
      // passing user data
      sessionUsername = HttpContext.Session.GetString("SessionUsername");
      sessionRole = HttpContext.Session.GetString("SessionRole");
      sessionName = HttpContext.Session.GetString("SessionName");
      sessionToken = HttpContext.Session.GetString("SessionToken");
    }

    protected bool isManager()
    {
      GetSessionInfo();

      if (sessionRole == "Manager")
        return true;
      else
        return false;
    }

    public void SetSessionInfo(UserSession user)
    {
      // set session info
      HttpContext.Session.SetObjectAsJson("UserInfo", user);
      HttpContext.Session.SetString("SessionUsername", user.acc_username);
      HttpContext.Session.SetString("SessionRole", user.acc_role);
      HttpContext.Session.SetString("SessionName", user.acc_name);
      HttpContext.Session.SetString("SessionToken", user.acc_session);

      GetSessionInfo();
    }

    protected void ClearSessionInfo()
    {
      // clear session info
      HttpContext.Session.Clear();
    }
  }
}
