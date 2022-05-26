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
    private readonly IRoomBookingService _roomBookingService;
    public room_bookingController(IRoomBookingService roomBookingService)
    {
      _roomBookingService = roomBookingService;
    }

    /// <summary>
    /// Book a room by creating data in DB (Normal)
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<room_booking>/1
    [HttpPost("1")]
    public async Task<Response<room_booking>> BookUnpaid([FromBody] room_booking room)
    {
      return await _roomBookingService.BookUnpaid(room);
    }

    /// <summary>
    /// Book a room by creating data in DB (VIP)
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<room_booking>/2
    [HttpPost("2")]
    public async Task<Response<room_booking>> BookPaid([FromBody] room_booking room)
    {
      return await _roomBookingService.BookPaid(room);
    }
  }
}
