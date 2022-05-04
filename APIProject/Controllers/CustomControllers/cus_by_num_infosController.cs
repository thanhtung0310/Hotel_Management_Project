﻿using BusinessLayer.IService;
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
        private ICusByNumInfoService _cusByNumInfoService;
        public cus_by_num_infosController(ICusByNumInfoService cusByNumInfoService)
        {
            _cusByNumInfoService = cusByNumInfoService;
        }

        // GET api/<cus_by_num_infosController>/0123456789
        [HttpGet("{num}")]
        public async Task<Response<cus_info>> GetCustomerByNum(string num)
        {
            return await _cusByNumInfoService.GetCustomerByNum(num);
        }
    }
}