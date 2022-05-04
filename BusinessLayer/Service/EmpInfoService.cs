using BusinessLayer.Extentions;
using BusinessLayer.IService;
using Dapper;
using DataLayer;
using Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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

        public async Task<Response<emp_info>> GetEmployeeByID(int id)
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

        public async Task<Response<emp_info>> CreateEmployee(emp_info emp)
        {
            var response = new Response<emp_info>();
            try
            {
                _provider.Open();                
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@id", emp.emp_id)
                    .AddParam("@username", emp.acc_username)
                    .AddParam("@pwd", emp.acc_password)
                    .AddParam("@name", emp.emp_name);
                var check = _provider.QueryFirstOrDefaultAsync<emp_info>("emp_id_get", emp.emp_id, commandType: CommandType.StoredProcedure);
                if (check != null)
                {
                    var empInfo = await _provider.QueryFirstOrDefaultAsync<emp_info>("emp_info_insert", param, commandType: CommandType.StoredProcedure);
                    response.Data = empInfo;
                    response.successResp();
                }
                else
                {
                    response.errorResp();
                }
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<Response<emp_info>> DeleteEmployeeByID(int id)
        {
            var response = new Response<emp_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@id", id);
                var check = _provider.QueryFirstOrDefaultAsync<emp_info>("emp_id_get", id, commandType: CommandType.StoredProcedure);
                if (check != null)
                {
                    var empInfo = await _provider.QueryFirstOrDefaultAsync<emp_info>("emp_info_delete", param, commandType: CommandType.StoredProcedure);
                    response.Data = empInfo;
                    response.successResp();
                }
                else
                {
                    response.errorResp();
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
