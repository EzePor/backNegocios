using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backNegocio.DataContext;
using backNegocio.Models.Detalles;
using Microsoft.AspNetCore.Cors;

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
                                 .Include(p => p.DetallesProducto)
                                 .ThenInclude(dp => dp.producto)
                                 .Include(p => p.DetallesImpresion)
                                 .ThenInclude(di => di.impresion)
                                 .ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido
                                       .Include(p => p.DetallesProducto)
                                       .ThenInclude(dp => dp.producto)
                                       .Include(p => p.DetallesImpresion)
                                       .ThenInclude(di => di.impresion)
                                       .FirstOrDefaultAsync(p => p.id == id);

            if (pedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            return pedido;
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetPedidosByClienteId(int clienteId)
        {
            var pedidos = await _context.Pedido
                .Include(p => p.DetallesProducto)
                .ThenInclude(dp => dp.producto)
                .Include(p => p.DetallesImpresion)
                .ThenInclude(di => di.impresion)
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();

            if (pedidos == null || !pedidos.Any())
            {
                return NotFound("No se encontraron pedidos para el cliente especificado.");
            }

            return Ok(pedidos);
        }

        // PUT: api/Pedidos/5 - Actualizar Pedido
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedidoActualizado)
        {
            if (id != pedidoActualizado.id)
            {
                return BadRequest("El ID del pedido no coincide.");
            }

            // Validación para no permitir actualizar pedidos eliminados
            var pedidoExistente = await _context.Pedido.FindAsync(id);
            if (pedidoExistente == null)
            {
                return NotFound("Pedido no encontrado.");
            }
            if (pedidoExistente.eliminado)
            {
                return BadRequest("No se puede actualizar un pedido eliminado.");
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
                    return NotFound("El pedido ya no existe.");
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
        [EnableCors("AllowAll")]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido nuevoPedido)
        {
            // Validaciones antes de guardar
            if (nuevoPedido == null)
            {
                return BadRequest("El pedido no puede estar vacío.");
            }
            if (nuevoPedido.ClienteId <= 0)
            {
                return BadRequest("El pedido debe tener un cliente válido.");
            }
            if (nuevoPedido.DetallesProducto == null || !nuevoPedido.DetallesProducto.Any())
            {
                return BadRequest("El pedido debe contener al menos un producto.");
            }

            if (nuevoPedido.DetallesImpresion == null || !nuevoPedido.DetallesImpresion.Any())
            {
                return BadRequest("El pedido debe contener al menos una impresión.");
            }

            try
            {
                // Agregar el nuevo pedido
                _context.Pedido.Add(nuevoPedido);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPedido), new { id = nuevoPedido.id }, nuevoPedido);
            }
            catch (DbUpdateException ex)
            {
                // Aquí podrías loguear el error si es necesario
                return StatusCode(500, $"Error al guardar el pedido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inesperado: {ex.Message}");
            }
        }

        // DELETE: api/Pedidos/5 - Eliminar Pedido y Detalles Asociados
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedido
                                       .Include(p => p.DetallesProducto)
                                       .Include(p => p.DetallesImpresion)
                                       .FirstOrDefaultAsync(p => p.id == id);

            if (pedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            // Marcar como eliminado en lugar de borrarlo físicamente (si aplica en tu negocio)
            pedido.eliminado = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.id == id);
        }
    }
}
