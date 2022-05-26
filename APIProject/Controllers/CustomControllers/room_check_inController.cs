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
    public class room_check_inController : ControllerBase
    {
        private readonly IRoomCheckInService _roomCheckInService;
        public room_check_inController(IRoomCheckInService roomCheckInService)
        {
            _roomCheckInService = roomCheckInService;
        }

        /// <summary>
        /// Check in Room by update data in DB
        /// </summary>
        /// <returns></returns>
        // POST api/<room_check_in>
        [HttpPost]
        public async Task<Response<room_check_in>> CheckInRoom([FromBody] input_check_data input)
        {
            return await _roomCheckInService.CheckInRoom(input);
        }
    }
}
