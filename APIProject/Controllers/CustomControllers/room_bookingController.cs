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
    public class room_bookingController : ControllerBase
    {
        private IRoomBookingService _roomBookingService;
        public room_bookingController(IRoomBookingService roomBookingService)
        {
            _roomBookingService = roomBookingService;
        }

        /// <summary>
        /// Book a room by creating data in DB
        /// </summary>
        /// <param name="room"></param>
        /// <param name="booking_type"></param>
        /// <returns></returns>
        // POST api/<room_booking>
        [HttpPost]
        public async Task<Response<room_booking>> CreateRoom([FromBody] room_booking room, int booking_type)
        {
            return await _roomBookingService.BookRoom(room, booking_type);
        }
    }
}
