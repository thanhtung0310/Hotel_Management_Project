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
    /// <param name="room_id"></param>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<room_check_in>/1
    [HttpPost("1/{room_id}")]
    public async Task<Response<room_booking>> CheckOutUnpaidRoom(int room_id, [FromBody] room_booking room)
    {
      return await _roomCheckOutService.CheckOutUnpaidRoom(room_id, room);
    }

    /// <summary>
    /// Check out room by update data in DB
    /// </summary>
    /// <param name="room_id"></param>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<room_check_in>/1
    [HttpPost("2/{room_id}")]
    public async Task<Response<room_booking>> CheckOutPaidRoom(int room_id, [FromBody] room_booking room)
    {
      return await _roomCheckOutService.CheckOutPaidRoom(room_id, room);
    }
  }
}
