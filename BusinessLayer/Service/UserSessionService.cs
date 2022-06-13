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
  public class UserSessionService : IUserSessionService
  {
    private readonly IDbConnection _provider;
    public UserSessionService(IDbConnection provider) : base()
    {
      _provider = provider;
    }

    // get a list of users information
    public async Task<Response<List<UserSession>>> GetUserSessions()
    {
      var response = new Response<List<UserSession>>();
      try
      {
        _provider.Open();
        var userSessions = await _provider.QueryAsync<UserSession>("user_session_info_get", null, commandType: CommandType.StoredProcedure);
        response.Data = userSessions.AsList();
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

    // get user information by acc_username
    public async Task<Response<UserSession>> GetUserSession(string acc_username)
    {
      var response = new Response<UserSession>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@acc_username", acc_username);
        var userSessions = await _provider.QueryFirstOrDefaultAsync<UserSession>("single_user_session_info_get", param, commandType: CommandType.StoredProcedure);
        response.Data = userSessions;
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

    // get and check password before login
    public async Task<Response<UserSession>> Login(UserSession user)
    {
      var response = new Response<UserSession>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@acc_username", user.acc_username);
        var check = _provider.ExecuteReader("single_user_session_info_get", param, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          var userSession = await _provider.QueryFirstOrDefaultAsync<UserSession>("user_password_session_get", param, commandType: CommandType.StoredProcedure);
          response.Data = userSession;
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

    // clear session when log out
    public async Task<Response<UserSession>> Logout(string acc_username)
    {
      var response = new Response<UserSession>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@acc_username", acc_username);
        var check = _provider.ExecuteReader("single_user_session_info_get", param, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          var userSession = await _provider.QueryFirstOrDefaultAsync<UserSession>("user_session_clear", param, commandType: CommandType.StoredProcedure);
          response.Data = userSession;
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

    // update user information
    public async Task<Response<UserSession>> UpdateUser(UserSession newData)
    {
      var response = new Response<UserSession>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@acc_username", newData.acc_username)
          .AddParam("@acc_name", newData.acc_name)
          .AddParam("@acc_dob", newData.acc_dob)
          .AddParam("@acc_contact_number", newData.acc_contact_number);
        DynamicParameters param1 = new DynamicParameters()
            .AddParam("@acc_username", newData.acc_username);

        var check = _provider.ExecuteReader("single_user_session_info_get", param1, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          var newUser = await _provider.QueryFirstOrDefaultAsync<UserSession>("single_user_session_info_update", param, commandType: CommandType.StoredProcedure);
          response.Data = newUser;
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

    // update user password (hashed)
    public async Task<Response<UserSession>> UpdatePassword(UserSession newData)
    {
      var response = new Response<UserSession>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
          .AddParam("@acc_username", newData.acc_username)
          .AddParam("@acc_new_password", newData.acc_password);
        DynamicParameters param1 = new DynamicParameters()
            .AddParam("@acc_username", newData.acc_username);

        var check = _provider.ExecuteReader("single_user_session_info_get", param1, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          await _provider.QueryFirstOrDefaultAsync<UserSession>("single_user_password_update", param, commandType: CommandType.StoredProcedure);
          response.Data = newData;
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

    // create user session and saved in database
    public async Task<Response<UserSession>> StartSession(UserSession newData)
    {
      var response = new Response<UserSession>();
      try
      {
        _provider.Open();
        DynamicParameters param = new DynamicParameters()
            .AddParam("@acc_username", newData.acc_username)
            .AddParam("@acc_session", newData.acc_session);
        DynamicParameters param1 = new DynamicParameters()
            .AddParam("@acc_username", newData.acc_username);
        var check = _provider.ExecuteReader("single_user_session_info_get", param1, commandType: CommandType.StoredProcedure);
        if (((DbDataReader)check).HasRows == true)
        {
          var userSession = await _provider.QueryFirstOrDefaultAsync<UserSession>("user_session_start", param, commandType: CommandType.StoredProcedure);
          response.Data = userSession;
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
