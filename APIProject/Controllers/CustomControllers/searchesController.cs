using BusinessLayer.IService;
using DatabaseProvider;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers.CustomControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class searchesController : ControllerBase
  {
    private readonly ISearchService _searchService;
    public searchesController(ISearchService searchService)
    {
      _searchService = searchService;
    }

    /// <summary>
    /// Get customer's information by name
    /// </summary>
    /// <param name="searchString"></param>
    /// <returns></returns>
    // GET api/<searchesController>/customer-thoang
    [HttpGet("customer-{searchString}")]
    public async Task<Response<List<customer>>> SearchCustomerByName(string searchString)
    {
      return await _searchService.SearchCustomerByName(searchString);
    }

    /// <summary>
    /// Get employee's information by name
    /// </summary>
    /// <param name="searchString"></param>
    /// <returns></returns>
    // GET api/<searchesController>/employee-viet
    [HttpGet("employee-{searchString}")]
    public async Task<Response<List<employee>>> SearchEmployeeByName(string searchString)
    {
      return await _searchService.SearchEmployeeByName(searchString);
    }
  }
}
