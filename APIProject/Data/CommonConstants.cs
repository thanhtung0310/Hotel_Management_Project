using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Data
{
  public class CommonConstants
  {
    public static string USER_SESSION_TOKEN = "USER_SESSION_TOKEN";
    public static string USER_ROLE = "Guest";
    public static string USER_NAME = "";
    public static string USER_USERNAME = "USER_USERNAME";
    public static UserSession USER_INFO { get; set; }
  }
}
