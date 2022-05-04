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
    public class room_infosController : ControllerBase
    {
        private IRoomInfoService _roomInfoService;
        public room_infosController (IRoomInfoService roomInfoService)
        {
            _roomInfoService = roomInfoService;
        }
        // GET: api/<room_infosController>
        [HttpGet]
        public async Task<Response<List<room_info>>> GetRoomList()
        {
            return await _roomInfoService.GetRoomList();
        }

        // GET api/<room_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<List<room_info>>> GetRoomByID(int id)
        {
            return await _roomInfoService.GetRoomByID(id);
        }

        // POST api/<room_infosController>
        [HttpPost]
        public async Task<Response<room_info>> CreateRoom(room_info room)
        {
            return await _roomInfoService.CreateRoom(room);
        }

        // DELETE api/<room_infosController>/5
        [HttpDelete("{id}")]
        public async Task<Response<room_info>> DeleteRoomByID(int id)
        {
            return await _roomInfoService.DeleteRoomByID(id);
        }
    }
}
