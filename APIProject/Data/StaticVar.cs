using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace APIProject.Data
{
  public static class StaticVar
  {
    public static string baseUrl = "https://localhost:44304/api"; //IIS
    //public static string baseUrl = "https://localhost:5001/api"; //Kestrel
    
    public static string HashedPassword(string pwd)
    {
      // hash Password
      int costParam = 13;
      return BCryptNet.HashPassword(pwd, costParam);
    }

    public static T GetData<T>(string apiResponse)
    {
      JObject jsonArray = JObject.Parse(apiResponse);
      var dataField = jsonArray["data"];
      T data = JsonConvert.DeserializeObject<T>(dataField.ToString());
      return data;
    }
  }
}
