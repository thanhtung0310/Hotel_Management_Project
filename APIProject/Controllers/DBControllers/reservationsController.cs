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
    public class reservationsController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public reservationsController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<reservation>>> Getreservation()
        {
            return await _context.reservation.ToListAsync();
        }

        // GET: api/reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<reservation>> Getreservation(int id)
        {
            var reservation = await _context.reservation.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreservation(int id, reservation reservation)
        {
            if (id != reservation.resvervation_id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservationExists(id))
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

        // POST: api/reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<reservation>> Postreservation(reservation reservation)
        {
            _context.reservation.Add(reservation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (reservationExists(reservation.resvervation_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getreservation", new { id = reservation.resvervation_id }, reservation);
        }

        // DELETE: api/reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereservation(int id)
        {
            var reservation = await _context.reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.reservation.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool reservationExists(int id)
        {
            return _context.reservation.Any(e => e.resvervation_id == id);
        }
    }
}
