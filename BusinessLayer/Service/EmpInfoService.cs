using BusinessLayer.IService;
using Dapper;
using DatabaseProvider;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class EmpInfoService: BaseController<employee>, IEmpInfoService
    {
        private readonly IDbConnection _provider;
        public EmpInfoService(IDbConnection provider): base()
        {
            _provider = provider;
        }
        public async Task<Response<List<employee>>> GetEmployeeList()
        {
            var response = new Response<List<employee>>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                var empInfo = await _provider.QueryAsync<employee>("[dbo].[emp_info_get]", param ?? null, commandType: CommandType.StoredProcedure);
                response.Data = empInfo.AsList();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
        public async Task<Response<employee>> GetEmployeeByID(int id)
        {
            var response = new Response<employee>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                var empInfo = await _provider.QueryAsync<employee>("[dbo].[emp_info_get]", param ?? null , commandType: CommandType.StoredProcedure);
                response.Data = empInfo.FirstOrDefault();
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
    }
}
