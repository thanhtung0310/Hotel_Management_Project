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
    public class accountsController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public accountsController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<account>>> Getaccount()
        {
            return await _context.account.ToListAsync();
        }

        // GET: api/accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<account>> Getaccount(int id)
        {
            var account = await _context.account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaccount(int id, account account)
        {
            if (id != account.acc_id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountExists(id))
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

        // POST: api/accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<account>> Postaccount(account account)
        {
            _context.account.Add(account);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (accountExists(account.acc_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getaccount", new { id = account.acc_id }, account);
        }

        // DELETE: api/accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteaccount(int id)
        {
            var account = await _context.account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.account.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool accountExists(int id)
        {
            return _context.account.Any(e => e.acc_id == id);
        }
    }
}
