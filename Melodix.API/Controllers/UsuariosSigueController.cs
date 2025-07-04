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
    public class UsuariosSigueController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosSigueController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosSigue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioSigue>>> GetUsuarioSigue()
        {
            return await _context.UsuariosSigue.ToListAsync();
        }

        // GET: api/UsuariosSigue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioSigue>> GetUsuarioSigue(int id)
        {
            var usuarioSigue = await _context.UsuariosSigue.FindAsync(id);

            if (usuarioSigue == null)
            {
                return NotFound();
            }

            return usuarioSigue;
        }

        // PUT: api/UsuariosSigue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioSigue(int id, UsuarioSigue usuarioSigue)
        {
            if (id != usuarioSigue.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioSigue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioSigueExists(id))
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

        // POST: api/UsuariosSigue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioSigue>> PostUsuarioSigue(UsuarioSigue usuarioSigue)
        {
            _context.UsuariosSigue.Add(usuarioSigue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioSigue", new { id = usuarioSigue.Id }, usuarioSigue);
        }

        // DELETE: api/UsuariosSigue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioSigue(int id)
        {
            var usuarioSigue = await _context.UsuariosSigue.FindAsync(id);
            if (usuarioSigue == null)
            {
                return NotFound();
            }

            _context.UsuariosSigue.Remove(usuarioSigue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioSigueExists(int id)
        {
            return _context.UsuariosSigue.Any(e => e.Id == id);
        }
    }
}
