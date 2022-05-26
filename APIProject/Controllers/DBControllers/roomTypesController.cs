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
    public class roomTypesController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public roomTypesController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/roomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<roomType>>> GetroomType()
        {
            return await _context.roomType.ToListAsync();
        }

        // GET: api/roomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<roomType>> GetroomType(int id)
        {
            var roomType = await _context.roomType.FindAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }

            return roomType;
        }

        // PUT: api/roomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutroomType(int id, roomType roomType)
        {
            if (id != roomType.room_type_id)
            {
                return BadRequest();
            }

            _context.Entry(roomType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomTypeExists(id))
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

        // POST: api/roomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<roomType>> PostroomType(roomType roomType)
        {
            _context.roomType.Add(roomType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (roomTypeExists(roomType.room_type_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetroomType", new { id = roomType.room_type_id }, roomType);
        }

        // DELETE: api/roomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteroomType(int id)
        {
            var roomType = await _context.roomType.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.roomType.Remove(roomType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool roomTypeExists(int id)
        {
            return _context.roomType.Any(e => e.room_type_id == id);
        }
    }
}
