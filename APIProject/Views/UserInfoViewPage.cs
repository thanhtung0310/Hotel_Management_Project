using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace APIProject.Views
{
  public abstract class MyBaseViewPage<T> : WebViewPage<T>
  {
    public string Username
    {
      get { return (string)ViewBag.SessionUsername; }
    }

    public string Role
    {
      get { return (string)ViewBag.SessionRole; }
    }

    public string Name
    {
      get { return (string)ViewBag.SessionName; }
    }
  }

  public abstract class MyBaseViewPage : MyBaseViewPage<dynamic>
  {
  }
}
