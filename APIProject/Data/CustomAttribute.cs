using APIProject.Controllers;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using BusinessLayer.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Data
{
  public class UserAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      //UserSession user = context.HttpContext.Session.GetObjectFromJson<UserSession>("userInfo");
      string sessionRole = context.HttpContext.Session.GetString("SessionRole");

      if (sessionRole == null)
      {
        context.Result = new RedirectResult("/Home/Blocked");
      }
      else
      {
        //what ever you want, or nothing at all
      }
    }
  }
  public class AdminAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      //UserSession user = context.HttpContext.Session.GetObjectFromJson<UserSession>("userInfo");
      string sessionRole = context.HttpContext.Session.GetString("SessionRole");

      if (sessionRole != "Manager")
      {
        context.Result = new RedirectResult("/Home/Restrict");
      }
      else
      {
        //what ever you want, or nothing at all
      }
    }
  }
}
