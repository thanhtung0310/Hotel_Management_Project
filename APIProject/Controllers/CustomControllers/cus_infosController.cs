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
        private readonly ICusInfoService _cusInfoService;
        public cus_infosController(ICusInfoService cusInfoService)
        {
            _cusInfoService = cusInfoService;
        }

        /// <summary>
        /// Get a list of all customers
        /// </summary>
        /// <returns></returns>
        // GET: api/<cus_infosController>
        [HttpGet]
        public async Task<Response<List<cus_info>>> GetCustomerList()
        {
            return await _cusInfoService.GetCustomerList();
        }

        /// <summary>
        /// Get customer's information by customer ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<cus_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<cus_info>> GetCustomerByID(int id)
        {
            return await _cusInfoService.GetCustomerByID(id);
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        // POST api/<cus_infosController>
        [HttpPost]
        public async Task<Response<cus_info>> CreateCustomer([FromBody] cus_info cus)
        {
            return await _cusInfoService.CreateCustomer(cus);
        }

        /// <summary>
        /// Delete customer's information by customer ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<cus_infosController>/5
        [HttpDelete("{id}")]
        public async Task<Response<cus_info>> DeleteCustomerByID(int id)
        {
            return await _cusInfoService.DeleteCustomerByID(id);
        }
    }
}
