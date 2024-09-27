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

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Cliente
                                 .Include(c => c.Pedidos)
                                 .ToListAsync();
        }

        // GET: api/Cliente individual
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesProducto)
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesImpresion)
                                        .FirstOrDefaultAsync(c => c.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: api/Clientes/5/pedidos - Obtener todos los pedidos de un cliente
        [HttpGet("{id}/pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosCliente(int id)
        {
            var cliente = await _context.Cliente
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesProducto)
                                        .Include(c => c.Pedidos)
                                        .ThenInclude(p => p.DetallesImpresion)
                                        .FirstOrDefaultAsync(c => c.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente.Pedidos.ToList();
        }

        // PUT: api/Clientes/5 - Actualizar Cliente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.id)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes - Crear Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.id }, cliente);
        }

        // DELETE: api/Clientes/5 - Eliminar Cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente
                                        .Include(c => c.Pedidos)
                                        .FirstOrDefaultAsync(c => c.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            // Eliminamos el cliente y los pedidos asociados
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.id == id);
        }
    }
}
