using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador_Melodix;

namespace Melodix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasPistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListasPistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ListasPistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaPista>>> GetListaPista()
        {
            return await _context.ListasPistas.ToListAsync();
        }

        // GET: api/ListasPistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaPista>> GetListaPista(int id)
        {
            var listaPista = await _context.ListasPistas.FindAsync(id);

            if (listaPista == null)
            {
                return NotFound();
            }

            return listaPista;
        }

        // PUT: api/ListasPistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaPista(int id, ListaPista listaPista)
        {
            if (id != listaPista.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaPista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaPistaExists(id))
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

        // POST: api/ListasPistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListaPista>> PostListaPista(ListaPista listaPista)
        {
            _context.ListasPistas.Add(listaPista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaPista", new { id = listaPista.Id }, listaPista);
        }

        // DELETE: api/ListasPistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaPista(int id)
        {
            var listaPista = await _context.ListasPistas.FindAsync(id);
            if (listaPista == null)
            {
                return NotFound();
            }

            _context.ListasPistas.Remove(listaPista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaPistaExists(int id)
        {
            return _context.ListasPistas.Any(e => e.Id == id);
        }
    }
}
