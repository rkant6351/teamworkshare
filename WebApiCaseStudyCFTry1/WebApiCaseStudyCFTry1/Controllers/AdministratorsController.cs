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
    public class AdministratorsController : ControllerBase
    {
        private readonly CaseStudyDbContext _context;

        public AdministratorsController(CaseStudyDbContext context)
        {
            _context = context;
        }

        // GET: api/Administrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrators>>> GetAdministrators()
        {
          if (_context.Administrators == null)
          {
              return NotFound();
          }
            return await _context.Administrators.ToListAsync();
        }

        // GET: api/Administrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrators>> GetAdministrators(int id)
        {
          if (_context.Administrators == null)
          {
              return NotFound();
          }
            var administrators = await _context.Administrators.FindAsync(id);

            if (administrators == null)
            {
                return NotFound();
            }

            return administrators;
        }

        // PUT: api/Administrators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrators(int id, Administrators administrators)
        {
            if (id != administrators.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(administrators).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorsExists(id))
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

        // POST: api/Administrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrators>> PostAdministrators(Administrators administrators)
        {
          if (_context.Administrators == null)
          {
              return Problem("Entity set 'CaseStudyDbContext.Administrators'  is null.");
          }
            _context.Administrators.Add(administrators);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrators", new { id = administrators.AdminId }, administrators);
        }

        // DELETE: api/Administrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrators(int id)
        {
            if (_context.Administrators == null)
            {
                return NotFound();
            }
            var administrators = await _context.Administrators.FindAsync(id);
            if (administrators == null)
            {
                return NotFound();
            }

            _context.Administrators.Remove(administrators);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministratorsExists(int id)
        {
            return (_context.Administrators?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
