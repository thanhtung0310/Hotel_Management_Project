using BusinessLayer.IService;
using Dapper;
using Entity;
using DatabaseProvider;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Extentions;
using System.Data.Common;

namespace BusinessLayer.Service
{
  public class SearchService: BaseController<customer>, BaseController<employee>, ISearchService
  {
    private readonly IDbConnection _provider;
    public SearchService(IDbConnection provider): base()
    {
      _provider = provider;
    }
    public async Task<Response<List<customer>>> SearchCustomerByName(string searchString)
    {
      var response = new Response<List<customer>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@search_string", searchString);
        var check = _provider.ExecuteReader("customer_by_name_search", param, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          var cusInfo = await _provider.QueryAsync<customer>("customer_by_name_search", param, commandType: CommandType.StoredProcedure);
          response.Data = cusInfo.AsList();
          response.successResp();
        }
        else
        {
          response.errorResp();
        }
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

    public async Task<Response<List<employee>>> SearchEmployeeByName(string searchString)
    {
      var response = new Response<List<employee>>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@search_string", searchString);
        var check = _provider.ExecuteReader("employee_by_name_search", param, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          var empInfo = await _provider.QueryAsync<employee>("employee_by_name_search", param, commandType: CommandType.StoredProcedure);
          response.Data = empInfo.AsList();
          response.successResp();
        }
        else
        {
          response.errorResp();
        }
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
