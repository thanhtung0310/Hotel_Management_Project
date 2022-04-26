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
    public class roomStatusController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public roomStatusController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/roomStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<roomStatu>>> GetroomStatu()
        {
            return await _context.roomStatu.ToListAsync();
        }

        // GET: api/roomStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<roomStatu>> GetroomStatu(int id)
        {
            var roomStatu = await _context.roomStatu.FindAsync(id);

            if (roomStatu == null)
            {
                return NotFound();
            }

            return roomStatu;
        }

        // PUT: api/roomStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutroomStatu(int id, roomStatu roomStatu)
        {
            if (id != roomStatu.room_status_id)
            {
                return BadRequest();
            }

            _context.Entry(roomStatu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomStatuExists(id))
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
        public async Task<ActionResult<roomStatu>> PostroomStatu(roomStatu roomStatu)
        {
            _context.roomStatu.Add(roomStatu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (roomStatuExists(roomStatu.room_status_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetroomStatu", new { id = roomStatu.room_status_id }, roomStatu);
        }

        // DELETE: api/roomStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteroomStatu(int id)
        {
            var roomStatu = await _context.roomStatu.FindAsync(id);
            if (roomStatu == null)
            {
                return NotFound();
            }

            _context.roomStatu.Remove(roomStatu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool roomStatuExists(int id)
        {
            return _context.roomStatu.Any(e => e.room_status_id == id);
        }
    }
}
