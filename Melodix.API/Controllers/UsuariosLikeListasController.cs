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
    public class UsuariosLikeListasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosLikeListasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosLikeListas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioLikeLista>>> GetUsuarioLikeLista()
        {
            return await _context.UsuariosLikeListas.ToListAsync();
        }

        // GET: api/UsuariosLikeListas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioLikeLista>> GetUsuarioLikeLista(int id)
        {
            var usuarioLikeLista = await _context.UsuariosLikeListas.FindAsync(id);

            if (usuarioLikeLista == null)
            {
                return NotFound();
            }

            return usuarioLikeLista;
        }

        // PUT: api/UsuariosLikeListas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioLikeLista(int id, UsuarioLikeLista usuarioLikeLista)
        {
            if (id != usuarioLikeLista.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioLikeLista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioLikeListaExists(id))
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

        // POST: api/UsuariosLikeListas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioLikeLista>> PostUsuarioLikeLista(UsuarioLikeLista usuarioLikeLista)
        {
            _context.UsuariosLikeListas.Add(usuarioLikeLista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioLikeLista", new { id = usuarioLikeLista.Id }, usuarioLikeLista);
        }

        // DELETE: api/UsuariosLikeListas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioLikeLista(int id)
        {
            var usuarioLikeLista = await _context.UsuariosLikeListas.FindAsync(id);
            if (usuarioLikeLista == null)
            {
                return NotFound();
            }

            _context.UsuariosLikeListas.Remove(usuarioLikeLista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioLikeListaExists(int id)
        {
            return _context.UsuariosLikeListas.Any(e => e.Id == id);
        }
    }
}
