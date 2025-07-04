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
    public class UsuariosLikePistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosLikePistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosLikePistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioLikePista>>> GetUsuarioLikePista()
        {
            return await _context.UsuariosLikePistas.ToListAsync();
        }

        // GET: api/UsuariosLikePistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioLikePista>> GetUsuarioLikePista(int id)
        {
            var usuarioLikePista = await _context.UsuariosLikePistas.FindAsync(id);

            if (usuarioLikePista == null)
            {
                return NotFound();
            }

            return usuarioLikePista;
        }

        // PUT: api/UsuariosLikePistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioLikePista(int id, UsuarioLikePista usuarioLikePista)
        {
            if (id != usuarioLikePista.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioLikePista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioLikePistaExists(id))
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

        // POST: api/UsuariosLikePistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioLikePista>> PostUsuarioLikePista(UsuarioLikePista usuarioLikePista)
        {
            _context.UsuariosLikePistas.Add(usuarioLikePista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioLikePista", new { id = usuarioLikePista.Id }, usuarioLikePista);
        }

        // DELETE: api/UsuariosLikePistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioLikePista(int id)
        {
            var usuarioLikePista = await _context.UsuariosLikePistas.FindAsync(id);
            if (usuarioLikePista == null)
            {
                return NotFound();
            }

            _context.UsuariosLikePistas.Remove(usuarioLikePista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioLikePistaExists(int id)
        {
            return _context.UsuariosLikePistas.Any(e => e.Id == id);
        }
    }
}
