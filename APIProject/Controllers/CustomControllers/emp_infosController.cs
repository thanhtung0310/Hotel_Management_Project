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
        private IEmpInfoService _empInfoService;
        public emp_infosController(IEmpInfoService empInfoService)
        {
            _empInfoService = empInfoService;
        }

        // GET: api/<emp_infosController>
        [HttpGet]
        public async Task<Response<List<emp_info>>> GetEmployeeList()
        {
            return await _empInfoService.GetEmployeeList();
        }

        // GET api/<emp_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<emp_info>> GetEmployeeByID(int id)
        {
            return await _empInfoService.GetEmployeeByID(id);
        }

        // POST api/<emp_infosController>
        [HttpPost]
        public async Task<Response<emp_info>> CreateEmployee([FromBody] emp_info emp, int id, string name, string username, string pwd, int role_id)
        {
            return await _empInfoService.CreateEmployee(emp, id, name, username, pwd, role_id);
        }
    }
}
