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
    public class paymentTypesController : ControllerBase
    {
        private readonly APIProjectContext _context;

        public paymentTypesController(APIProjectContext context)
        {
            _context = context;
        }

        // GET: api/paymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<paymentType>>> GetpaymentType()
        {
            return await _context.paymentType.ToListAsync();
        }

        // GET: api/paymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<paymentType>> GetpaymentType(int id)
        {
            var paymentType = await _context.paymentType.FindAsync(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return paymentType;
        }

        // PUT: api/paymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutpaymentType(int id, paymentType paymentType)
        {
            if (id != paymentType.payment_type_id)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentTypeExists(id))
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

        // POST: api/paymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<paymentType>> PostpaymentType(paymentType paymentType)
        {
            _context.paymentType.Add(paymentType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (paymentTypeExists(paymentType.payment_type_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetpaymentType", new { id = paymentType.payment_type_id }, paymentType);
        }

        // DELETE: api/paymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletepaymentType(int id)
        {
            var paymentType = await _context.paymentType.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.paymentType.Remove(paymentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool paymentTypeExists(int id)
        {
            return _context.paymentType.Any(e => e.payment_type_id == id);
        }
    }
}
