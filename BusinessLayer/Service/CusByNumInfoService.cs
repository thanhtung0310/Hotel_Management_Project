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
  public class CusByNumInfoService : BaseController<cus_info>, ICusByNumInfoService
  {
    private readonly IDbConnection _provider;
    public CusByNumInfoService(IDbConnection provider) : base()
    {
      _provider = provider;
    }

    public async Task<Response<cus_info>> GetCustomerByNum(string num)
    {
      var response = new Response<cus_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@num", num);
        var cusInfo = await _provider.QueryAsync<cus_info>("customer_info_number_get", param, commandType: CommandType.StoredProcedure);

        response.Data = cusInfo.FirstOrDefault();
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
