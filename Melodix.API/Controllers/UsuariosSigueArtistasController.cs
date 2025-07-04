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
    public class UsuariosSigueArtistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosSigueArtistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosSigueArtistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioSigueArtista>>> GetUsuarioSigueArtista()
        {
            return await _context.UsuariosSigueArtistas.ToListAsync();
        }

        // GET: api/UsuariosSigueArtistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioSigueArtista>> GetUsuarioSigueArtista(int id)
        {
            var usuarioSigueArtista = await _context.UsuariosSigueArtistas.FindAsync(id);

            if (usuarioSigueArtista == null)
            {
                return NotFound();
            }

            return usuarioSigueArtista;
        }

        // PUT: api/UsuariosSigueArtistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioSigueArtista(int id, UsuarioSigueArtista usuarioSigueArtista)
        {
            if (id != usuarioSigueArtista.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioSigueArtista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioSigueArtistaExists(id))
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

        // POST: api/UsuariosSigueArtistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioSigueArtista>> PostUsuarioSigueArtista(UsuarioSigueArtista usuarioSigueArtista)
        {
            _context.UsuariosSigueArtistas.Add(usuarioSigueArtista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioSigueArtista", new { id = usuarioSigueArtista.Id }, usuarioSigueArtista);
        }

        // DELETE: api/UsuariosSigueArtistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioSigueArtista(int id)
        {
            var usuarioSigueArtista = await _context.UsuariosSigueArtistas.FindAsync(id);
            if (usuarioSigueArtista == null)
            {
                return NotFound();
            }

            _context.UsuariosSigueArtistas.Remove(usuarioSigueArtista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioSigueArtistaExists(int id)
        {
            return _context.UsuariosSigueArtistas.Any(e => e.Id == id);
        }
    }
}
