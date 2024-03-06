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
    public class Order_itemsController : ControllerBase
    {
        private readonly CaseStudyDbContext _context;

        public Order_itemsController(CaseStudyDbContext context)
        {
            _context = context;
        }

        // GET: api/Order_items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_items>>> GetOrder_items()
        {
          if (_context.Order_items == null)
          {
              return NotFound();
          }
            return await _context.Order_items.ToListAsync();
        }

        // GET: api/Order_items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_items>> GetOrder_items(int id)
        {
          if (_context.Order_items == null)
          {
              return NotFound();
          }
            var order_items = await _context.Order_items.FindAsync(id);

            if (order_items == null)
            {
                return NotFound();
            }

            return order_items;
        }

        // PUT: api/Order_items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder_items(int id, Order_items order_items)
        {
            if (id != order_items.OrderItemId)
            {
                return BadRequest();
            }

            _context.Entry(order_items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_itemsExists(id))
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

        // POST: api/Order_items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order_items>> PostOrder_items(Order_items order_items)
        {
          if (_context.Order_items == null)
          {
              return Problem("Entity set 'CaseStudyDbContext.Order_items'  is null.");
          }
            _context.Order_items.Add(order_items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_items", new { id = order_items.OrderItemId }, order_items);
        }

        // DELETE: api/Order_items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder_items(int id)
        {
            if (_context.Order_items == null)
            {
                return NotFound();
            }
            var order_items = await _context.Order_items.FindAsync(id);
            if (order_items == null)
            {
                return NotFound();
            }

            _context.Order_items.Remove(order_items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Order_itemsExists(int id)
        {
            return (_context.Order_items?.Any(e => e.OrderItemId == id)).GetValueOrDefault();
        }
    }
}
