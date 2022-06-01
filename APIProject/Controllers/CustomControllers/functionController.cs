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
  public class functionController : ControllerBase
  {
    private readonly IFunctionService _functionService;
    public functionController(IFunctionService functionService)
    {
      _functionService = functionService;
    }

    /// <summary>
    /// Book a room by creating data in DB (Normal)
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<function>/booking/1
    [HttpPost("booking/1")]
    public async Task<Response<room_booking>> BookUnpaid([FromBody] room_booking room)
    {
      return await _functionService.BookUnpaid(room);
    }

    /// <summary>
    /// Book a room by creating data in DB (VIP)
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<function>/booking/2
    [HttpPost("booking/2")]
    public async Task<Response<room_booking>> BookPaid([FromBody] room_booking room)
    {
      return await _functionService.BookPaid(room);
    }

    /// <summary>
    /// Check in Room by update data in DB
    /// </summary>
    /// <returns></returns>
    // POST api/<function>/check_in
    [HttpPost("check_in")]
    public async Task<Response<room_check_in>> CheckInRoom([FromBody] input_check_data input)
    {
      return await _functionService.CheckInRoom(input);
    }

    /// <summary>
    /// Check out room by update data in DB
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<function>/check_out>/1
    [HttpPost("check_out/1")]
    public async Task<Response<room_check_out>> CheckOutUnpaidRoom([FromBody] room_check_out room)
    {
      return await _functionService.CheckOutUnpaidRoom(room);
    }

    /// <summary>
    /// Check out room by update data in DB
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    // POST api/<function>/check_out>/2
    [HttpPost("check_out/2")]
    public async Task<Response<room_check_out>> CheckOutPaidRoom([FromBody] room_check_out room)
    {
      return await _functionService.CheckOutPaidRoom(room);
    }

    /// <summary>
    /// Convert single room
    /// </summary>
    /// <returns></returns>
    // GET: api/<function>/vacant_convert/1
    [HttpGet("vacant_convert/{id}")]
    public async Task<Response<room_info>> SingleRoomConvert(int id)
    {
      return await _functionService.SingleRoomConvert(id);
    }

    /// <summary>
    /// Convert single room
    /// </summary>
    /// <returns></returns>
    // GET: api/<function>/vacant_convert
    [HttpGet("vacant_convert")]
    public async Task<Response<room_info>> RoomConvert()
    {
      return await _functionService.RoomConvert();
    }
  }
}
