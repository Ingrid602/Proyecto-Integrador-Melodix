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
    public class UsuariosSigueListasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosSigueListasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosSigueListas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioSigueLista>>> GetUsuarioSigueLista()
        {
            return await _context.UsuariosSigueListas.ToListAsync();
        }

        // GET: api/UsuariosSigueListas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioSigueLista>> GetUsuarioSigueLista(int id)
        {
            var usuarioSigueLista = await _context.UsuariosSigueListas.FindAsync(id);

            if (usuarioSigueLista == null)
            {
                return NotFound();
            }

            return usuarioSigueLista;
        }

        // PUT: api/UsuariosSigueListas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioSigueLista(int id, UsuarioSigueLista usuarioSigueLista)
        {
            if (id != usuarioSigueLista.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioSigueLista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioSigueListaExists(id))
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

        // POST: api/UsuariosSigueListas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioSigueLista>> PostUsuarioSigueLista(UsuarioSigueLista usuarioSigueLista)
        {
            _context.UsuariosSigueListas.Add(usuarioSigueLista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioSigueLista", new { id = usuarioSigueLista.Id }, usuarioSigueLista);
        }

        // DELETE: api/UsuariosSigueListas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioSigueLista(int id)
        {
            var usuarioSigueLista = await _context.UsuariosSigueListas.FindAsync(id);
            if (usuarioSigueLista == null)
            {
                return NotFound();
            }

            _context.UsuariosSigueListas.Remove(usuarioSigueLista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioSigueListaExists(int id)
        {
            return _context.UsuariosSigueListas.Any(e => e.Id == id);
        }
    }
}
