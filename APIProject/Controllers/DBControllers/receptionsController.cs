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
    public class receptionsController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public receptionsController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/receptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<reception>>> Getreception()
        {
            return await _context.reception.ToListAsync();
        }

        // GET: api/receptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<reception>> Getreception(int id)
        {
            var reception = await _context.reception.FindAsync(id);

            if (reception == null)
            {
                return NotFound();
            }

            return reception;
        }

        // PUT: api/receptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreception(int id, reception reception)
        {
            if (id != reception.reception_id)
            {
                return BadRequest();
            }

            _context.Entry(reception).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!receptionExists(id))
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

        // POST: api/receptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<reception>> Postreception(reception reception)
        {
            _context.reception.Add(reception);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (receptionExists(reception.reception_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getreception", new { id = reception.reception_id }, reception);
        }

        // DELETE: api/receptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereception(int id)
        {
            var reception = await _context.reception.FindAsync(id);
            if (reception == null)
            {
                return NotFound();
            }

            _context.reception.Remove(reception);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool receptionExists(int id)
        {
            return _context.reception.Any(e => e.reception_id == id);
        }
    }
}
