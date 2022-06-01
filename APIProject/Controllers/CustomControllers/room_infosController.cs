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
    public room_infosController(IRoomInfoService roomInfoService)
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

    /// <summary>
    /// Get room which has been booked by Room type ID
    /// </summary>
    /// <returns></returns>
    // GET api/<room_infosController>/booked
    [HttpGet("booked")]
    public async Task<Response<List<booked_room_info>>> GetBookedRoomList()
    {
      return await _roomInfoService.GetBookedRoomList();
    }

    /// <summary>
    /// Get room which has been booked by Room type ID
    /// </summary>
    /// <param name="room_type_id"></param>
    /// <returns></returns>
    // GET api/<room_infosController>/booked/type/1
    [HttpGet("booked/type/{room_type_id}")]
    public async Task<Response<List<booked_room_info>>> GetBookedRoomByType(int room_type_id)
    {
      return await _roomInfoService.GetBookedRoomByType(room_type_id);
    }

    /// <summary>
    /// Get room's information by room number
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    // GET: api/<room_infosController>/num/101
    [HttpGet("num/{num}")]
    public async Task<Response<room_info>> GetRoomByNum(int num)
    {
      return await _roomInfoService.GetRoomByNum(num);
    }

    /// <summary>
    /// Get room information by Room status ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // GET api/<room_infosController>/status/5
    [HttpGet("status/{id}")]
    public async Task<Response<List<room_status_info>>> GetRoomByStatusID(int id)
    {
      return await _roomInfoService.GetRoomByStatusID(id);
    }
  }
}
