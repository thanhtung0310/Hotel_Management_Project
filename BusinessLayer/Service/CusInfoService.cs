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
using System.Data.Common;

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

    public async Task<Response<List<checked_cus_info>>> GetCheckedinCusList()
    {
      var response = new Response<List<checked_cus_info>>();
      try
      {
        _provider.Open();
        var cusInfo = await _provider.QueryAsync<checked_cus_info>("customer_check_in_room_list", commandType: CommandType.StoredProcedure);
        response.Data = cusInfo.AsList();
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

    public async Task<Response<cus_info>> GetCustomerByID(int id)
    {
      var response = new Response<cus_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@id", id);
        var cusInfo = await _provider.QueryFirstOrDefaultAsync<cus_info>("cus_id_get", param, commandType: CommandType.StoredProcedure);
        response.Data = cusInfo;
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

    public async Task<Response<cus_info>> GetID()
    {
      var response = new Response<cus_info>();
      try
      {
        _provider.Open();
        var cusInfo = await _provider.QueryFirstOrDefaultAsync<cus_info>("customer_id_get", null, commandType: CommandType.StoredProcedure);
        response.Data = cusInfo;
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

    public async Task<Response<cus_info>> CreateCustomer(cus_info cus)
    {
      var response = new Response<cus_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@id", cus.customer_id)
            .AddParam("@fname", cus.customer_first_name)
            .AddParam("@lname", cus.customer_last_name)
            .AddParam("@address", cus.customer_address)
            .AddParam("@num", cus.customer_contact_number);
        DynamicParameters param1 = new DynamicParameters()
            .AddParam("@id", cus.customer_id);
        var check = _provider.ExecuteReader("cus_id_get", param1, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == false)
        {
          await _provider.QueryFirstOrDefaultAsync<cus_info>("cus_info_insert", param, commandType: CommandType.StoredProcedure);
          response.Data = cus;
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

    public async Task<Response<cus_info>> UpdateCustomer(cus_info cus)
    {
      var response = new Response<cus_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@id", cus.customer_id)
          .AddParam("@fname", cus.customer_first_name)
          .AddParam("@lname", cus.customer_last_name)
          .AddParam("@address", cus.customer_address)
          .AddParam("@num", cus.customer_contact_number);
        DynamicParameters param1 = new DynamicParameters()
          .AddParam("@id", cus.customer_id);
        var check = _provider.ExecuteReader("cus_id_get", param1, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          await _provider.QueryFirstOrDefaultAsync<cus_info>("cus_info_update", param, commandType: CommandType.StoredProcedure);
          response.Data = cus;
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

    public async Task<Response<cus_info>> DeleteCustomerByID(int id)
    {
      var response = new Response<cus_info>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@id", id);
        var check = _provider.ExecuteReader("cus_id_get", param, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          await _provider.QueryFirstOrDefaultAsync<cus_info>("cus_info_delete", param, commandType: CommandType.StoredProcedure);
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
