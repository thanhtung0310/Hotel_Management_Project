using BusinessLayer.IService;
using Dapper;
using DatabaseProvider;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class EmployeeService : BaseController<employee>, IEmployeeService
    {
        private readonly IDbConnection _provider;
        public EmployeeService(IDbConnection provider) : base()
        {
            _provider = provider;
        }

        string IEmployeeService.GetEmployeeName(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<employee>> GetEmployees()
        {
            var response = new List<employee>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                var employees = await _provider.QueryAsync<employee>("emp_info_get", param ?? null, commandType: CommandType.StoredProcedure);
                //var employees = await _provider.QueryAsync<employee>("select * from employee;");
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }

        public async Task<List<employee>> GetEmployeeID(int? id)
        {
            var response = new List<employee>();
            try
            {
                _provider.Open();
                DynamicParameters param = new DynamicParameters();
                var employees = await _provider.QueryAsync<employee>("emp_info_get", param ?? null, commandType: CommandType.StoredProcedure);
                //var employees = await _provider.QueryAsync<employee>("'select * from employee where emp_id = '" + id + "'");
            }
            catch
            {
                throw;
            }
            finally
            {
                _provider.Close();
            }
            return response;
        }
    }
}
