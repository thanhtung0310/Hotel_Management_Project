using BusinessLayer.IService;
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
    public class cus_infosController : ControllerBase
    {
        private ICusInfoService _cusInfoService;
        public cus_infosController(ICusInfoService cusInfoService)
        {
            _cusInfoService = cusInfoService;
        }

        // GET: api/<cus_infosController>
        [HttpGet]
        public async Task<Response<List<cus_info>>> GetCustomerList()
        {
            return await _cusInfoService.GetCustomerList();
        }

        // GET api/<cus_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<cus_info>> GetCustomerByID(int id)
        {
            return await _cusInfoService.GetCustomerByID(id);
        }

        // POST api/<cus_infosController>
        [HttpPost]
        public async Task<Response<List<cus_info>>> CreateCustomer([FromBody] cus_info cus)
        {
            return await _cusInfoService.CreateCustomer(cus);
        }
    }
}
