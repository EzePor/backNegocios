using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backNegocio.DataContext;
using backNegocio.Models.Detalles;

namespace backNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly NegocioContext _context;

        public PedidosController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedido
                                 .Include(p => p.DetallesPedido)
                                 .Include(p => p.DetallesImpresion)
                                 .ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido
                                       .Include(p => p.DetallesPedido)
                                       .Include(p => p.DetallesImpresion)
                                       .FirstOrDefaultAsync(p => p.id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidos/5 - Actualizar Pedido
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedidoActualizado)
        {
            if (id != pedidoActualizado.id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoActualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidos - Crear Pedido con Detalles
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido nuevoPedido)
        {
            _context.Pedido.Add(nuevoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = nuevoPedido.id }, nuevoPedido);
        }

        // DELETE: api/Pedidos/5 - Eliminar Pedido y Detalles Asociados
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedido
                                       .Include(p => p.DetallesPedido)
                                       .Include(p => p.DetallesImpresion)
                                       .FirstOrDefaultAsync(p => p.id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.id == id);
        }
    }
}
