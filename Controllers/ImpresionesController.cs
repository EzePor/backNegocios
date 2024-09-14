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
    public class ImpresionesController : ControllerBase
    {
        private readonly NegocioContext _context;

        public ImpresionesController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/Impresiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Impresion>>> GetImpresion()
        {
            return await _context.Impresion.ToListAsync();
        }

        // GET: api/Impresiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Impresion>> GetImpresion(int id)
        {
            var impresion = await _context.Impresion.FindAsync(id);

            if (impresion == null)
            {
                return NotFound();
            }

            return impresion;
        }

        // PUT: api/Impresiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImpresion(int id, Impresion impresion)
        {
            if (id != impresion.id)
            {
                return BadRequest();
            }

            _context.Entry(impresion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpresionExists(id))
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

        // POST: api/Impresiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Impresion>> PostImpresion(Impresion impresion)
        {
            _context.Impresion.Add(impresion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImpresion", new { id = impresion.id }, impresion);
        }

        // DELETE: api/Impresiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImpresion(int id)
        {
            var impresion = await _context.Impresion.FindAsync(id);
            if (impresion == null)
            {
                return NotFound();
            }

            _context.Impresion.Remove(impresion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImpresionExists(int id)
        {
            return _context.Impresion.Any(e => e.id == id);
        }
    }
}
