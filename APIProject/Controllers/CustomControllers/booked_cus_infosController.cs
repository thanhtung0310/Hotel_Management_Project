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
    public class booked_cus_infosController : ControllerBase
    {
        private IBookedCusInfoService _cusInfoService;
        public booked_cus_infosController(IBookedCusInfoService cusInfoService)
        {
            _cusInfoService = cusInfoService;
        }

        /// <summary>
        /// Get customer who has booked room by their contact number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        // GET api/<booked_cus_infosController>/0123456786
        [HttpGet("{num}")]
        public async Task<Response<booked_cus_info>> GetBookedCustomerByNum(string num)
        {
            return await _cusInfoService.GetBookedCustomerByNum(num);
        }
    }
}
