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
    public class cus_by_num_infosController : ControllerBase
    {
        private readonly ICusByNumInfoService _cusByNumInfoService;
        public cus_by_num_infosController(ICusByNumInfoService cusByNumInfoService)
        {
            _cusByNumInfoService = cusByNumInfoService;
        }

        /// <summary>
        /// Get customer's information by their contact number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        // GET api/<cus_by_num_infosController>/0123456789
        [HttpGet("{num}")]
        public async Task<Response<cus_info>> GetCustomerByNum(string num)
        {
            return await _cusByNumInfoService.GetCustomerByNum(num);
        }
    }
}
