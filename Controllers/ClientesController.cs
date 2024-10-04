using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backNegocio.DataContext;
using backNegocio.Models.Commons;
using backNegocio.Models.Detalles;

namespace backNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly NegocioContext _context;

        public ClientesController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/Clientes - Obtener todos los clientes no eliminados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Cliente
                                 .Where(c => !c.eliminado)  // Solo clientes no eliminados
                                 .Include(c => c.Pedidos)
                                 .ToListAsync();
        }

        // GET: api/Cliente individual no eliminado
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente
                                        .Where(c => !c.eliminado)  // Solo cliente no eliminado
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesProducto)
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesImpresion)
                                        .FirstOrDefaultAsync(c => c.id == id);

            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return cliente;
        }

        // GET: api/Clientes/5/pedidos - Obtener pedidos de un cliente no eliminado
        [HttpGet("{id}/pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosCliente(int id)
        {
            var cliente = await _context.Cliente
                                        .Where(c => !c.eliminado)  // Solo cliente no eliminado
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesProducto)
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesImpresion)
                                        .FirstOrDefaultAsync(c => c.id == id);

            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return cliente.Pedidos.ToList();
        }

        // PUT: api/Clientes/5 - Actualizar cliente no eliminado
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.id)
            {
                return BadRequest("El ID del cliente no coincide.");
            }

            var clienteExistente = await _context.Cliente.FindAsync(id);

            if (clienteExistente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            if (clienteExistente.eliminado)
            {
                return BadRequest("No se puede actualizar un cliente eliminado.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound("El cliente ya no existe.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes - Crear cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.id }, cliente);
        }

        // DELETE: api/Clientes/5 - Marcar cliente como eliminado
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente
                                        .Include(c => c.Pedidos)
                                        .FirstOrDefaultAsync(c => c.id == id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            // Marcar como eliminado en lugar de eliminar físicamente
            cliente.eliminado = true;
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.id == id);
        }
    }
}
