using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backNegocio.DataContext;
using backNegocio.Models.Detalles;
using Microsoft.AspNetCore.Cors;
using backNegocio.Enums;

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
            // Filtra los pedidos que no están eliminados
            return await _context.Pedido
                                  .Where(p => !p.eliminado) // Filtrar los que no están eliminados
                                  .Include(c => c.cliente)
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
                                       .Include(c => c.cliente)
                                       .Include(p => p.DetallesProducto)
                                       .ThenInclude(dp => dp.producto)
                                       .Include(p => p.DetallesImpresion)
                                       .ThenInclude(di => di.impresion)
                                       .FirstOrDefaultAsync(p => p.id == id && !p.eliminado); // Filtrar los que no están eliminados

            if (pedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            return pedido;
        }

        [HttpGet("estado/{estado}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosPorEstado(string estado)
        {
            // Intenta parsear el estado al enum
            if (!Enum.TryParse<EstadoPedidoEnum>(estado, out var estadoPedido))
            {
                return BadRequest("Estado no válido.");
            }

            // Filtra los pedidos por estado
            var pedidos = await _context.Pedido
                .Where(p => p.estadoPedido == estadoPedido)
                .ToListAsync();

            return Ok(pedidos);
        }



        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetPedidosByClienteId(int clienteId)
        {
            var pedidos = await _context.Pedido
                .Include(c => c.cliente)
                .Include(p => p.DetallesProducto)
                .ThenInclude(dp => dp.producto)
                .Include(p => p.DetallesImpresion)
                .ThenInclude(di => di.impresion)
                .Where(p => p.ClienteId == clienteId && !p.eliminado) // Filtrar los que no están eliminados
                .ToListAsync();

            if (pedidos == null || !pedidos.Any())
            {
                return NotFound("No se encontraron pedidos para el cliente especificado.");
            }

            return Ok(pedidos);
        }

        // PUT: api/Pedidos/5 - Actualizar Pedido
        // PUT: api/Pedidos/5 - Actualizar Pedido
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedidoActualizado)
        {
            if (id != pedidoActualizado.id)
            {
                return BadRequest("El ID del pedido no coincide.");
            }

            // Obtener el pedido existente junto con sus detalles
            var pedidoExistente = await _context.Pedido
                .Include(p => p.DetallesProducto)
                .Include(p => p.DetallesImpresion)
                .FirstOrDefaultAsync(p => p.id == id);

            if (pedidoExistente == null || pedidoExistente.eliminado)
            {
                return NotFound("Pedido no encontrado o está eliminado.");
            }

            // Actualizar propiedades básicas del pedido
            pedidoExistente.ModoPagoId = pedidoActualizado.ModoPagoId;
            pedidoExistente.estadoPedido = pedidoActualizado.estadoPedido;
            pedidoExistente.FuePagado = pedidoActualizado.FuePagado;

            // *** Manejo de productos eliminados ***
            // Filtrar los productos que no están en el pedido actualizado
            var productosEliminados = pedidoExistente.DetallesProducto
                .Where(dp => !pedidoActualizado.DetallesProducto.Any(dpa => dpa.ProductoId == dp.ProductoId))
                .ToList();

            // Eliminar los productos eliminados
            foreach (var productoEliminado in productosEliminados)
            {
                _context.DetalleProducto.Remove(productoEliminado);
            }

            // Manejo de DetallesProducto
            foreach (var detalleProductoActualizado in pedidoActualizado.DetallesProducto)
            {
                var detalleProductoExistente = pedidoExistente.DetallesProducto
                    .FirstOrDefault(dp => dp.ProductoId == detalleProductoActualizado.ProductoId);

                if (detalleProductoExistente != null)
                {
                    // Si el producto ya existe, actualiza su cantidad y precio
                    detalleProductoExistente.cantidad = detalleProductoActualizado.cantidad;
                    detalleProductoExistente.precioUnitario = detalleProductoActualizado.precioUnitario;
                }
                else
                {
                    // Si no existe, agregarlo como nuevo
                    pedidoExistente.DetallesProducto.Add(new DetalleProducto
                    {
                        ProductoId = detalleProductoActualizado.ProductoId,
                        cantidad = detalleProductoActualizado.cantidad,
                        precioUnitario = detalleProductoActualizado.precioUnitario
                    });
                }
            }

            // *** Manejo de impresiones eliminadas ***
            // Filtrar las impresiones que no están en el pedido actualizado
            var impresionesEliminadas = pedidoExistente.DetallesImpresion
                .Where(di => !pedidoActualizado.DetallesImpresion.Any(dia => dia.ImpresionId == di.ImpresionId))
                .ToList();

            // Eliminar las impresiones eliminadas
            foreach (var impresionEliminada in impresionesEliminadas)
            {
                _context.DetalleImpresion.Remove(impresionEliminada);
            }

            // Manejo de DetallesImpresion
            foreach (var detalleImpresionActualizado in pedidoActualizado.DetallesImpresion)
            {
                var detalleImpresionExistente = pedidoExistente.DetallesImpresion
                    .FirstOrDefault(di => di.ImpresionId == detalleImpresionActualizado.ImpresionId);

                if (detalleImpresionExistente != null)
                {
                    // Si la impresión ya existe, actualizar su cantidad y precio
                    detalleImpresionExistente.cantidad = detalleImpresionActualizado.cantidad;
                    detalleImpresionExistente.precioUnitario = detalleImpresionActualizado.precioUnitario;
                }
                else
                {
                    // Si no existe, agregarlo como nuevo
                    pedidoExistente.DetallesImpresion.Add(new DetalleImpresion
                    {
                        ImpresionId = detalleImpresionActualizado.ImpresionId,
                        cantidad = detalleImpresionActualizado.cantidad,
                        precioUnitario = detalleImpresionActualizado.precioUnitario
                    });
                }
            }

            try
            {
                // Guardar cambios
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
            if (nuevoPedido == null || nuevoPedido.ClienteId <= 0)
            {
                return BadRequest("El pedido debe contener información válida.");
            }

            // Verificar que el pedido tenga al menos un detalle de producto o un detalle de impresión
            if ((nuevoPedido.DetallesProducto == null || !nuevoPedido.DetallesProducto.Any()) &&
                (nuevoPedido.DetallesImpresion == null || !nuevoPedido.DetallesImpresion.Any()))
            {
                return BadRequest("El pedido debe contener al menos un producto o una impresión.");
            }

            // Agregar el pedido a la base de datos
            _context.Pedido.Add(nuevoPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = nuevoPedido.id }, nuevoPedido);
        }


        // DELETE: api/Pedidos/5 - Eliminar Pedido y Detalles Asociados (Soft Delete)
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

            // Marcar como eliminado en lugar de borrarlo físicamente
            pedido.eliminado = true;
            _context.Pedido.Update(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.id == id && !e.eliminado); // Verificar si existe y no está eliminado
        }
    }
}
