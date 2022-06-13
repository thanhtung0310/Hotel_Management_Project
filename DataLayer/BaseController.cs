using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface BaseController<T>
    {
        public virtual async Task<T> InsertAsync(IDbConnection _provider, string proc, T data)
        {
            dynamic response = null;
            try
            {
                _provider.Open();
                JObject converted = JsonConvert.DeserializeObject<JObject>(data.ToString());
                if (converted != null)
                {
                    Dictionary<string, string> keyValueMap = new();
                    DynamicParameters param = new();
                    foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                    {
                        if (keyValuePair.Key != "id")
                            param.Add($"@{keyValuePair.Key}", keyValuePair.Value);
                    }
                    response = await _provider.QueryAsync<T>(proc, param ?? null, commandType: CommandType.StoredProcedure);
                }
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<T> GetAsync(IDbConnection _provider, string proc, T data)
        {
            dynamic response = null;
            try
            {
                _provider.Open();
                JObject converted = JsonConvert.DeserializeObject<JObject>(data.ToString());
                if (converted != null)
                {
                    Dictionary<string, string> keyValueMap = new();
                    DynamicParameters param = new();
                    foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                    {
                        param.Add($"@{keyValuePair.Key}", keyValuePair.Value);
                    }
                    response = await _provider.QueryAsync<T>(proc, param ?? null, commandType: CommandType.StoredProcedure);
                }
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
    }
}
