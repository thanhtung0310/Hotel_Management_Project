using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
  public interface IUserSessionService
  {
    Task<Response<List<UserSession>>> GetUserSessions();
    Task<Response<UserSession>> GetUserSession(string acc_username);
    Task<Response<UserSession>> Login(UserSession user);
    Task<Response<UserSession>> UpdateUser(string acc_username, UserSession newData);
  }
}
