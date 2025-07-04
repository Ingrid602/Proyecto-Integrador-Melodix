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
    public class UsuariosLikesAlbumsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosLikesAlbumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosLikesAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioLikeAlbum>>> GetUsuarioLikeAlbum()
        {
            return await _context.UsuariosLikeAlbums.ToListAsync();
        }

        // GET: api/UsuariosLikesAlbums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioLikeAlbum>> GetUsuarioLikeAlbum(int id)
        {
            var usuarioLikeAlbum = await _context.UsuariosLikeAlbums.FindAsync(id);

            if (usuarioLikeAlbum == null)
            {
                return NotFound();
            }

            return usuarioLikeAlbum;
        }

        // PUT: api/UsuariosLikesAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioLikeAlbum(int id, UsuarioLikeAlbum usuarioLikeAlbum)
        {
            if (id != usuarioLikeAlbum.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioLikeAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioLikeAlbumExists(id))
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

        // POST: api/UsuariosLikesAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioLikeAlbum>> PostUsuarioLikeAlbum(UsuarioLikeAlbum usuarioLikeAlbum)
        {
            _context.UsuariosLikeAlbums.Add(usuarioLikeAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioLikeAlbum", new { id = usuarioLikeAlbum.Id }, usuarioLikeAlbum);
        }

        // DELETE: api/UsuariosLikesAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioLikeAlbum(int id)
        {
            var usuarioLikeAlbum = await _context.UsuariosLikeAlbums.FindAsync(id);
            if (usuarioLikeAlbum == null)
            {
                return NotFound();
            }

            _context.UsuariosLikeAlbums.Remove(usuarioLikeAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioLikeAlbumExists(int id)
        {
            return _context.UsuariosLikeAlbums.Any(e => e.Id == id);
        }
    }
}
