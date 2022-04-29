using BusinessLayer.IService;
using Dapper;
using Entity;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Extentions;

namespace BusinessLayer.Service
{
    public class CusInfoService : BaseController<cus_info>, ICusInfoService
    {
        private readonly IDbConnection _provider;
        public CusInfoService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        public async Task<Response<List<cus_info>>> GetCustomerList()
        {
            var response = new Response<List<cus_info>>();
            try
            {
                _provider.Open();
                var cusInfo = await _provider.QueryAsync<cus_info>("cus_info_get", commandType: CommandType.StoredProcedure);
                response.Data = cusInfo.AsList();
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<Response<cus_info>> GetCustomerByID(int id)
        {
            var response = new Response<cus_info>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters()
                    .AddParam("@id", id);
                var cusInfo = await _provider.QueryAsync<cus_info>("cus_id_get", param, commandType: CommandType.StoredProcedure);
                response.Data = cusInfo.FirstOrDefault();             
                response.successResp();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<Response<List<cus_info>>> CreateCustomer(cus_info cus)
        {
            var response = new Response<List<cus_info>>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                var empInfo = await _provider.QueryAsync<emp_info>("cus_info_insert", cus ?? null, commandType: CommandType.StoredProcedure);
                response.successResp();
                //response.Data = empInfo.<emp_info>();
            }
            finally
            {
                response.errorResp();
                _provider.Close();
            }
            return response;
        }
    }
}
