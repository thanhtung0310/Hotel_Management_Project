using BusinessLayer.IService;
using Dapper;
using Entity;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
  public class EmployeeService : BaseController<emp_info>, IEmployeeService
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

    public async Task<Response<List<emp_info>>> GetEmployees()
    {
      var response = new Response<List<emp_info>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters();
        var employees = await _provider.QueryAsync<emp_info>("emp_info_get", param ?? null, commandType: CommandType.StoredProcedure);
        response.Data = employees.AsList();
        response.successResp();
      }
      catch
      {
        response.errorResp();
      }
      finally
      {
        _provider.Close();
      }
      return response;
    }

    public async Task<Response<List<emp_info>>> GetEmployeeID(int? id)
    {
      var response = new Response<List<emp_info>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters();
        var employees = await _provider.QueryAsync<emp_info>("emp_info_get", id ?? null, commandType: CommandType.StoredProcedure);
        response.Data = employees.AsList();
        response.successResp();
      }
      catch
      {
        response.errorResp();
      }
      finally
      {
        _provider.Close();
      }
      return response;
    }
  }
}
