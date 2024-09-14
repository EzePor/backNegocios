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
    public class DetallePedidosController : ControllerBase
    {
        private readonly NegocioContext _context;

        public DetallePedidosController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/DetallePedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedido()
        {
            return await _context.DetallePedido.ToListAsync();
        }

        // GET: api/DetallePedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        // PUT: api/DetallePedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (id != detallePedido.id)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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

        // POST: api/DetallePedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido)
        {
            _context.DetallePedido.Add(detallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePedido", new { id = detallePedido.id }, detallePedido);
        }

        // DELETE: api/DetallePedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallePedido.Remove(detallePedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.id == id);
        }
    }
}
