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
    public class room_status_infosController : ControllerBase
    {
        private readonly IRoomStatusInfoService _roomStatusInfoService;
        public room_status_infosController (IRoomStatusInfoService roomStatusInfoService)
        {
            _roomStatusInfoService = roomStatusInfoService;
        }

        /// <summary>
        /// Get room information by Room status ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<room_status_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<List<room_status_info>>> GetRoomByStatusID(int id)
        {
            return await _roomStatusInfoService.GetRoomByStatusID(id);
        }
    }
}
