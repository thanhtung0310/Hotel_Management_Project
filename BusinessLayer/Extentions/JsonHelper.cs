using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer.Extentions
{
  public class JsonHelper
  {
    // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to
    // mặc định sử dụng System.Text.Json của Microsoft
    public static string Serialize<T>(T inputObject)
    {
      return JsonSerializer.Serialize(inputObject);
    }

    public static T Deserialize<T>(string jsonString)
    {
      if (string.IsNullOrEmpty(jsonString))
      {
        return default(T);
      }

      return JsonSerializer.Deserialize<T>(jsonString);
    }
    public static T DeserializeByNewtonsoft<T>(string jsonString)
    {
      if (string.IsNullOrEmpty(jsonString))
      {
        return default(T);
      }

      return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
    }
  }
}
