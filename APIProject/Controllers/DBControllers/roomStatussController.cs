using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using DatabaseProvider;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roomStatussController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public roomStatussController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/roomStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<roomStatus>>> GetRoomStatus()
        {
            return await _context.roomStatus.ToListAsync();
        }

        // GET: api/roomStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<roomStatus>> GetRoomStatus(int id)
        {
            var roomStatus = await _context.roomStatus.FindAsync(id);

            if (roomStatus == null)
            {
                return NotFound();
            }

            return roomStatus;
        }

        // PUT: api/roomStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomStatus(int id, roomStatus roomStatus)
        {
            if (id != roomStatus.room_status_id)
            {
                return BadRequest();
            }

            _context.Entry(roomStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/roomStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<roomStatus>> PostRoomStatus(roomStatus roomStatus)
        {
            _context.roomStatus.Add(roomStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomStatusExists(roomStatus.room_status_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomStatus", new { id = roomStatus.room_status_id }, roomStatus);
        }

        // DELETE: api/roomStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomStatus(int id)
        {
            var roomStatus = await _context.roomStatus.FindAsync(id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            _context.roomStatus.Remove(roomStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomStatusExists(int id)
        {
            return _context.roomStatus.Any(e => e.room_status_id == id);
        }
    }
}
