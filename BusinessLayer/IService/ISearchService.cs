using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProvider;
using Entity;

namespace BusinessLayer.IService
{
  public interface ISearchService
  {
    Task<Response<List<customer>>> SearchCustomerByName(string searchString);
    Task<Response<List<employee>>> SearchEmployeeByName(string searchString);
  }
}
