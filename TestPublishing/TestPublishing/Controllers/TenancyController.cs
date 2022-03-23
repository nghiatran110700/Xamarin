using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestPublishing.Model;

namespace TestPublishing.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TenancyController : ControllerBase
    {
        private readonly NccData _context;

        public TenancyController(NccData context)
        {
            _context = context;
        }

        // GET: api/Tenancy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenancy>>> GetTenancy()
        {
            return await _context.Tenancy.ToListAsync();
        }

        // GET: api/Tenancy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenancy>> GetTenancy(Guid id)
        {
            var tenancy = await _context.Tenancy.FindAsync(id);

            if (tenancy == null)
            {
                return NotFound();
            }

            return tenancy;
        }

        // PUT: api/Tenancy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenancy(Guid id, Tenancy tenancy)
        {
            if (id != tenancy.TenancyK)
            {
                return BadRequest();
            }

            _context.Entry(tenancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenancyExists(id))
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

        // POST: api/Tenancy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tenancy>> PostTenancy(Tenancy tenancy)
        {
            _context.Tenancy.Add(tenancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenancy", new { id = tenancy.TenancyK }, tenancy);
        }

        // DELETE: api/Tenancy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenancy(Guid id)
        {
            var tenancy = await _context.Tenancy.FindAsync(id);
            if (tenancy == null)
            {
                return NotFound();
            }

            _context.Tenancy.Remove(tenancy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TenancyExists(Guid id)
        {
            return _context.Tenancy.Any(e => e.TenancyK == id);
        }
    }
}
