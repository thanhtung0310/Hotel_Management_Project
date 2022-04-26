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
    public class rolesController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public rolesController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<role>>> Getrole()
        {
            return await _context.role.ToListAsync();
        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<role>> Getrole(int id)
        {
            var role = await _context.role.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrole(int id, role role)
        {
            if (id != role.role_id)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roleExists(id))
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

        // POST: api/roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<role>> Postrole(role role)
        {
            _context.role.Add(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (roleExists(role.role_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getrole", new { id = role.role_id }, role);
        }

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterole(int id)
        {
            var role = await _context.role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.role.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool roleExists(int id)
        {
            return _context.role.Any(e => e.role_id == id);
        }
    }
}
