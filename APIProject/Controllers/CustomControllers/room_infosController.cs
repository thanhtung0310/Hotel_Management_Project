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
        private readonly IRoomInfoService _roomInfoService;
        public room_infosController (IRoomInfoService roomInfoService)
        {
            _roomInfoService = roomInfoService;
        }

        /// <summary>
        /// Get a list of all room
        /// </summary>
        /// <returns></returns>
        // GET: api/<room_infosController>
        [HttpGet]
        public async Task<Response<List<room_info>>> GetRoomList()
        {
            return await _roomInfoService.GetRoomList();
        }

        /// <summary>
        /// Get a list of rooms by Room type ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<room_infosController>/5
        [HttpGet("{id}")]
        public async Task<Response<List<room_info>>> GetRoomByID(int id)
        {
            return await _roomInfoService.GetRoomByID(id);
        }

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        // POST api/<room_infosController>
        [HttpPost]
        public async Task<Response<room_info>> CreateRoom(room_info room)
        {
            return await _roomInfoService.CreateRoom(room);
        }

        /// <summary>
        /// Delete room by room number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        // DELETE api/<room_infosController>/5
        [HttpDelete("{id}")]
        public async Task<Response<room_info>> DeleteRoomByID(string num)
        {
            return await _roomInfoService.DeleteRoomByID(num);
        }
    }
}
