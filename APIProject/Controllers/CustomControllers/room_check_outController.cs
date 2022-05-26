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
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<room_check_in>/1
    [HttpPost("1")]
    public async Task<Response<room_check_out>> CheckOutUnpaidRoom([FromBody] room_check_out room)
    {
      return await _roomCheckOutService.CheckOutUnpaidRoom(room);
    }

    /// <summary>
    /// Check out room by update data in DB
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<room_check_in>/1
    [HttpPost("2")]
    public async Task<Response<room_check_out>> CheckOutPaidRoom([FromBody] room_check_out room)
    {
      return await _roomCheckOutService.CheckOutPaidRoom(room);
    }
  }
}
