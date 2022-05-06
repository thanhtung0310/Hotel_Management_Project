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
    public class vacant_converterController : ControllerBase
    {
        private readonly IVacantConverterService _vacantConverterService;
        public vacant_converterController(IVacantConverterService vacantConverterService)
        {
            _vacantConverterService = vacantConverterService;
        }

        /// <summary>
        /// Convert single room
        /// </summary>
        /// <returns></returns>
        // GET: api/<room_infosController>
        [HttpGet("{id}")]
        public async Task<Response<room_info>> SingleRoomConvert(int id)
        {
            return await _vacantConverterService.SingleRoomConvert(id);
        }

        /// <summary>
        /// Convert single room
        /// </summary>
        /// <returns></returns>
        // GET: api/<room_infosController>
        [HttpGet]
        public async Task<Response<room_info>> RoomConvert()
        {
            return await _vacantConverterService.RoomConvert();
        }
    }
}
