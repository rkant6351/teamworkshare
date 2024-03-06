using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaseStudyCFTry1.Data;
using WebApiCaseStudyCFTry1.Models;

namespace WebApiCaseStudyCFTry1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly CaseStudyDbContext _context;

        public PaymentsController(CaseStudyDbContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPayments()
        {
          if (_context.Payments == null)
          {
              return NotFound();
          }
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetPayments(int id)
        {
          if (_context.Payments == null)
          {
              return NotFound();
          }
            var payments = await _context.Payments.FindAsync(id);

            if (payments == null)
            {
                return NotFound();
            }

            return payments;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayments(int id, Payments payments)
        {
            if (id != payments.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(payments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payments>> PostPayments(Payments payments)
        {
          if (_context.Payments == null)
          {
              return Problem("Entity set 'CaseStudyDbContext.Payments'  is null.");
          }
            _context.Payments.Add(payments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayments", new { id = payments.PaymentId }, payments);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayments(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentsExists(int id)
        {
            return (_context.Payments?.Any(e => e.PaymentId == id)).GetValueOrDefault();
        }
    }
}
