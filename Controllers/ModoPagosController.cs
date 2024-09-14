using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backNegocio.DataContext;
using backNegocio.Models.Commons;

namespace backNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModoPagosController : ControllerBase
    {
        private readonly NegocioContext _context;

        public ModoPagosController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/ModoPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModoPago>>> GetModoPago()
        {
            return await _context.ModoPago.ToListAsync();
        }

        // GET: api/ModoPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModoPago>> GetModoPago(int id)
        {
            var modoPago = await _context.ModoPago.FindAsync(id);

            if (modoPago == null)
            {
                return NotFound();
            }

            return modoPago;
        }

        // PUT: api/ModoPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModoPago(int id, ModoPago modoPago)
        {
            if (id != modoPago.id)
            {
                return BadRequest();
            }

            _context.Entry(modoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModoPagoExists(id))
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

        // POST: api/ModoPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModoPago>> PostModoPago(ModoPago modoPago)
        {
            _context.ModoPago.Add(modoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModoPago", new { id = modoPago.id }, modoPago);
        }

        // DELETE: api/ModoPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModoPago(int id)
        {
            var modoPago = await _context.ModoPago.FindAsync(id);
            if (modoPago == null)
            {
                return NotFound();
            }

            _context.ModoPago.Remove(modoPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModoPagoExists(int id)
        {
            return _context.ModoPago.Any(e => e.id == id);
        }
    }
}
