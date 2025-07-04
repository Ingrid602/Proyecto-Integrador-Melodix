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
    public class ListasReproduccionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListasReproduccionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ListasReproducciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListaReproduccion>>> GetListaReproduccion()
        {
            return await _context.ListasReproducciones.ToListAsync();
        }

        // GET: api/ListasReproducciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaReproduccion>> GetListaReproduccion(int id)
        {
            var listaReproduccion = await _context.ListasReproducciones.FindAsync(id);

            if (listaReproduccion == null)
            {
                return NotFound();
            }

            return listaReproduccion;
        }

        // PUT: api/ListasReproducciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaReproduccion(int id, ListaReproduccion listaReproduccion)
        {
            if (id != listaReproduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(listaReproduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaReproduccionExists(id))
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

        // POST: api/ListasReproducciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListaReproduccion>> PostListaReproduccion(ListaReproduccion listaReproduccion)
        {
            _context.ListasReproducciones.Add(listaReproduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListaReproduccion", new { id = listaReproduccion.Id }, listaReproduccion);
        }

        // DELETE: api/ListasReproducciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaReproduccion(int id)
        {
            var listaReproduccion = await _context.ListasReproducciones.FindAsync(id);
            if (listaReproduccion == null)
            {
                return NotFound();
            }

            _context.ListasReproducciones.Remove(listaReproduccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaReproduccionExists(int id)
        {
            return _context.ListasReproducciones.Any(e => e.Id == id);
        }
    }
}
