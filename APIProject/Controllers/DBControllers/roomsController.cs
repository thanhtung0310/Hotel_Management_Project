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
    public class roomsController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public roomsController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<room>>> Getroom()
        {
            return await _context.room.ToListAsync();
        }

        // GET: api/rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<room>> Getroom(int id)
        {
            var room = await _context.room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom(int id, room room)
        {
            if (id != room.room_id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomExists(id))
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

        // POST: api/rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<room>> Postroom(room room)
        {
            _context.room.Add(room);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (roomExists(room.room_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getroom", new { id = room.room_id }, room);
        }

        // DELETE: api/rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom(int id)
        {
            var room = await _context.room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.room.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool roomExists(int id)
        {
            return _context.room.Any(e => e.room_id == id);
        }
    }
}
