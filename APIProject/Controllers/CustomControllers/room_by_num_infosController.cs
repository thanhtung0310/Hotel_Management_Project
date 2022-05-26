using BusinessLayer.IService;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers.CustomControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class room_by_num_infosController : ControllerBase
    {
        private IRoomByNumInfoService _roomInfoService;
        public room_by_num_infosController(IRoomByNumInfoService roomInfoService)
        {
            _roomInfoService = roomInfoService;
        }

        /// <summary>
        /// Get room's information by room number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        // GET: api/<room_by_num_infosController>
        [HttpGet("{num}")]
        public async Task<Response<room_info>> GetRoomByNum(int num)
        {
            return await _roomInfoService.GetRoomByNum(num);
        }
    }
}
