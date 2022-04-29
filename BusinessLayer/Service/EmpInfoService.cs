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
    public class EmpInfoService: BaseController<emp_info>, IEmpInfoService
    {
        private readonly IDbConnection _provider;
        public EmpInfoService(IDbConnection provider): base()
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

        //public async Task<Response<List<emp_info>>> CreateEmployee(emp_info emp)
        //{
        //    var response = new Response<List<emp_info>>();
        //    try
        //    {
        //        _provider.Open();
        //        DynamicParameters param = new DynamicParameters();
        //        var empInfo = await _provider.QueryAsync<emp_info>("emp_info_insert", emp ?? null, commandType: CommandType.StoredProcedure);
        //        //response.Data = empInfo.<emp_info>();
        //    }
        //    finally
        //    {
        //        _provider.Close();
        //    }
        //    return response;
        //}
    }
}
