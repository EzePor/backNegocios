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
    public class DetalleProductosController : ControllerBase
    {
        private readonly NegocioContext _context;

        public DetalleProductosController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/DetalleProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleProducto>>> GetDetalleProducto()
        {
            return await _context.DetalleProducto.ToListAsync();
        }

        // GET: api/DetalleProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleProducto>> GetDetalleProducto(int id)
        {
            var detalleProducto = await _context.DetalleProducto.FindAsync(id);

            if (detalleProducto == null)
            {
                return NotFound();
            }

            return detalleProducto;
        }

        // PUT: api/DetalleProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleProducto(int id, DetalleProducto detalleProducto)
        {
            if (id != detalleProducto.id)
            {
                return BadRequest();
            }

            _context.Entry(detalleProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleProductoExists(id))
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

        // POST: api/DetalleProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleProducto>> PostDetalleProducto(DetalleProducto detalleProducto)
        {
            _context.DetalleProducto.Add(detalleProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleProducto", new { id = detalleProducto.id }, detalleProducto);
        }

        // DELETE: api/DetalleProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleProducto(int id)
        {
            var detalleProducto = await _context.DetalleProducto.FindAsync(id);
            if (detalleProducto == null)
            {
                return NotFound();
            }

            _context.DetalleProducto.Remove(detalleProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleProductoExists(int id)
        {
            return _context.DetalleProducto.Any(e => e.id == id);
        }
    }
}
