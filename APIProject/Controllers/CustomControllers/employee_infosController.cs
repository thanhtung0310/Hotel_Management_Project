using BusinessLayer.IService;
using DatabaseProvider;
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
    public class employee_infosController : ControllerBase
    {
        private IEmpInfoService _empInfoService;
        public employee_infosController(IEmpInfoService empInfoService)
        {
            _empInfoService = empInfoService;
        }

        //public async Task<ActionResult<IEnumerable<empInfo>>> GetEmployeeList()
        //{
        //    return await _empInfoService.GetEmployeeList();
        //}

        // GET: api/<employee_infosController>
        [HttpGet]
        public async Task<Response<List<employee>>> GetEmployeeList()
        {
            return await _empInfoService.GetEmployeeList();
        }

        // GET api/<employee_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<employee>> GetEmployeeByID(int id)
        {
            return await _empInfoService.GetEmployeeByID(id);
        }

        // POST api/<employee_infosController>
        [HttpPost]
        public void CreateEmployee([FromBody] string value)
        {
        }
    }
}
