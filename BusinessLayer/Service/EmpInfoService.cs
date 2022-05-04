using BusinessLayer.Extentions;
using BusinessLayer.IService;
using Dapper;
using DataLayer;
using Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class EmpInfoService : BaseController<emp_info>, IEmpInfoService
    {
        private readonly IDbConnection _provider;
        public EmpInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<List<emp_info>>> GetEmployeeList()
        {
            var response = new Response<List<emp_info>>();
            try
            {
                _provider.Open();
                var empInfo = await _provider.QueryAsync<emp_info>("emp_info_get", commandType: CommandType.StoredProcedure);
                response.Data = empInfo.AsList();
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<Response<emp_info>> GetEmployeeByID(int? id)
        {
            var response = new Response<emp_info>();
            try
            {
                _provider.Open();

                DynamicParameters param = new DynamicParameters()
                    .AddParam("@id", id);

                var empInfo = await _provider.QueryFirstOrDefaultAsync<emp_info>("emp_id_get", param, commandType: CommandType.StoredProcedure);
                response.Data = empInfo;
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<Response<emp_info>> CreateEmployee(emp_info emp, int id, string name, string username, string pwd, int role_id)
        {
            dynamic response = null;
            // var response = new Response<List<emp_info>>();
            try
            {
                _provider.Open();
                JObject newEmp = JsonConvert.DeserializeObject<JObject>(emp.ToString());
                if (newEmp != null)
                {
                    DynamicParameters param = new DynamicParameters();
                    foreach (KeyValuePair<string, JToken> keyValuePair in newEmp)
                    {
                        if (keyValuePair.Key != "id")
                        {
                            param.AddParam("", id)
                                .AddParam("", name)
                                .AddParam("", username)
                                .AddParam("", pwd)
                                .AddParam("", role_id);
                        }
                    }
                    response = (Response<List<emp_info>>)await _provider.QueryAsync<emp_info>("emp_info_insert", param, commandType: CommandType.StoredProcedure);
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
