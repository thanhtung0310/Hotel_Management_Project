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
    public class customersController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public customersController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customer>>> Getcustomer()
        {
            return await _context.customer.ToListAsync();
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<customer>> Getcustomer(int id)
        {
            var customer = await _context.customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcustomer(int id, customer customer)
        {
            if (id != customer.customer_id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerExists(id))
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

        // POST: api/customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<customer>> Postcustomer(customer customer)
        {
            _context.customer.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (customerExists(customer.customer_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getcustomer", new { id = customer.customer_id }, customer);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer(int id)
        {
            var customer = await _context.customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool customerExists(int id)
        {
            return _context.customer.Any(e => e.customer_id == id);
        }
    }
}
