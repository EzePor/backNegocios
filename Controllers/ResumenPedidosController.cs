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
    public class ResumenPedidosController : ControllerBase
    {
        private readonly NegocioContext _context;

        public ResumenPedidosController(NegocioContext context)
        {
            _context = context;
        }

        // GET: api/ResumenPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResumenPedido>>> GetResumenPedido()
        {
            return await _context.ResumenPedido.ToListAsync();
        }

        // GET: api/ResumenPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResumenPedido>> GetResumenPedido(int id)
        {
            var resumenPedido = await _context.ResumenPedido
                .Include(rp => rp.DetallesProducto)
                .Include(rp => rp.DetallesImpresion)
                .FirstOrDefaultAsync(rp => rp.Id == id);

            if (resumenPedido == null)
            {
                return NotFound();
            }

            return resumenPedido;
        }

        // GET: api/ResumenPedidos/cliente/5
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<ResumenPedido>>> GetResumenesPorCliente(int clienteId)
        {
            var resumenes = await _context.ResumenPedido
                .Include(rp => rp.DetallesProducto)
                .Include(rp => rp.DetallesImpresion)
                .Include(rp => rp.Pedido) // Incluye el pedido para obtener información del cliente
                .Where(rp => rp.Pedido.ClienteId == clienteId)
                .ToListAsync();

            if (resumenes == null || !resumenes.Any())
            {
                return NotFound();
            }

            return resumenes;
        }

        // PUT: api/ResumenPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResumenPedido(int id, ResumenPedido resumenPedido)
        {
            if (id != resumenPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(resumenPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumenPedidoExists(id))
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

        // POST: api/ResumenPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResumenPedido>> PostResumenPedido(ResumenPedido resumenPedido)
        {
            _context.ResumenPedido.Add(resumenPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResumenPedido", new { id = resumenPedido.Id }, resumenPedido);
        }

        // DELETE: api/ResumenPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResumenPedido(int id)
        {
            var resumenPedido = await _context.ResumenPedido.FindAsync(id);
            if (resumenPedido == null)
            {
                return NotFound();
            }

            _context.ResumenPedido.Remove(resumenPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResumenPedidoExists(int id)
        {
            return _context.ResumenPedido.Any(e => e.Id == id);
        }
    }
}
