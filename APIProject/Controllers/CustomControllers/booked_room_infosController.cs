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
  public class booked_room_infosController : ControllerBase
  {
    private readonly IBookedRoomInfoService _roomInfoService;
    public booked_room_infosController(IBookedRoomInfoService roomInfoService)
    {
      _roomInfoService = roomInfoService;
    }

    /// <summary>
    /// Get room which has been booked by Room type ID
    /// </summary>
    /// <returns></returns>
    // GET api/<booked_room_infosController>
    [HttpGet]
    public async Task<Response<List<booked_room_info>>> GetBookedRoomList()
    {
      return await _roomInfoService.GetBookedRoomList();
    }

    /// <summary>
    /// Get room which has been booked by Room type ID
    /// </summary>
    /// <param name="room_type_id"></param>
    /// <returns></returns>
    // GET api/<booked_room_infosController>/5
    [HttpGet("{room_type_id}")]
    public async Task<Response<List<booked_room_info>>> GetBookedRoomByType(int room_type_id)
    {
      return await _roomInfoService.GetBookedRoomByType(room_type_id);
    }
  }
}
