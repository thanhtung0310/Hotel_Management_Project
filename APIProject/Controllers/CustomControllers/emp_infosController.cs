using BusinessLayer.IService;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class emp_infosController : ControllerBase
  {
    private readonly IEmpInfoService _empInfoService;
    public emp_infosController(IEmpInfoService empInfoService)
    {
      _empInfoService = empInfoService;
    }

    /// <summary>
    /// Get a list of all employees
    /// </summary>
    /// <returns></returns>
    // GET: api/<emp_infosController>
    [HttpGet]
    public async Task<Response<List<emp_info>>> GetEmployeeList()
    {
      return await _empInfoService.GetEmployeeList();
    }

    /// <summary>
    /// Get information of a employee by Employee ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // GET api/<emp_infosController>/5
    [HttpGet("{id}")]
    public async Task<Response<emp_info>> GetEmployeeByID(int id)
    {
      return await _empInfoService.GetEmployeeByID(id);
    }

    /// <summary>
    /// Create new employee
    /// </summary>
    /// <param name="emp"></param>
    /// <returns></returns>
    // POST api/<emp_infosController>
    [HttpPost]
    public async Task<Response<emp_info>> CreateEmployee([FromBody] emp_info emp)
    {
      return await _empInfoService.CreateEmployee(emp);
    }

    /// <summary>
    /// Update employee
    /// </summary>
    /// <param name="emp"></param>
    /// <returns></returns>
    // PUT api/<emp_infosController>
    [HttpPut]
    public async Task<Response<emp_info>> UpdateEmployee( [FromBody] emp_info emp)
    {
      return await _empInfoService.UpdateEmployee(emp);
    }

    /// <summary>
    /// Delete employee by employee ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // DELETE api/<emp_infosController>/10
    [HttpDelete("{id}")]
    public async Task<Response<emp_info>> DeleteEmployeeByID(int id)
    {
      return await _empInfoService.DeleteEmployeeByID(id);
    }
  }
}
