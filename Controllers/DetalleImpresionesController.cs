using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backNegocio.DataContext;
using backNegocio.Models.Detalles;

namespace backNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleImpresionesController : ControllerBase
    {
        private readonly NegocioContext _context;

        public DetalleImpresionesController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/DetalleImpresiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleImpresion>>> GetDetalleImpresion()
        {
            return await _context.DetalleImpresion.ToListAsync();
        }

        // GET: api/DetalleImpresiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleImpresion>> GetDetalleImpresion(int id)
        {
            var detalleImpresion = await _context.DetalleImpresion.FindAsync(id);

            if (detalleImpresion == null)
            {
                return NotFound();
            }

            return detalleImpresion;
        }

        // PUT: api/DetalleImpresiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleImpresion(int id, DetalleImpresion detalleImpresion)
        {
            if (id != detalleImpresion.id)
            {
                return BadRequest();
            }

            _context.Entry(detalleImpresion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleImpresionExists(id))
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

        // POST: api/DetalleImpresiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleImpresion>> PostDetalleImpresion(DetalleImpresion detalleImpresion)
        {
            _context.DetalleImpresion.Add(detalleImpresion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleImpresion", new { id = detalleImpresion.id }, detalleImpresion);
        }

        // DELETE: api/DetalleImpresiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleImpresion(int id)
        {
            var detalleImpresion = await _context.DetalleImpresion.FindAsync(id);
            if (detalleImpresion == null)
            {
                return NotFound();
            }

            _context.DetalleImpresion.Remove(detalleImpresion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleImpresionExists(int id)
        {
            return _context.DetalleImpresion.Any(e => e.id == id);
        }
    }
}
