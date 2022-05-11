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
    public class room_check_outController : ControllerBase
    {
        private readonly IRoomCheckOutService _roomCheckOutService;
        public room_check_outController(IRoomCheckOutService roomCheckOutService)
        {
            _roomCheckOutService = roomCheckOutService;
        }

        /// <summary>
        /// Check out room by update data in DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        // PUT api/<room_check_in>/1
        [HttpPost]
        public async Task<Response<room_booking>> CheckInRoom(int checkout_type, int id, [FromBody] room_booking room)
        {
            return await _roomCheckOutService.CheckOutRoom(checkout_type, id, room);
        }
    }
}
