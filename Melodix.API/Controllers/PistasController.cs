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
    public class PistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pista>>> GetPista()
        {
            return await _context.Pistas.ToListAsync();
        }

        // GET: api/Pistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pista>> GetPista(int id)
        {
            var pista = await _context.Pistas.FindAsync(id);

            if (pista == null)
            {
                return NotFound();
            }

            return pista;
        }

        // PUT: api/Pistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPista(int id, Pista pista)
        {
            if (id != pista.Id)
            {
                return BadRequest();
            }

            _context.Entry(pista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PistaExists(id))
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

        // POST: api/Pistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pista>> PostPista(Pista pista)
        {
            _context.Pistas.Add(pista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPista", new { id = pista.Id }, pista);
        }

        // DELETE: api/Pistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePista(int id)
        {
            var pista = await _context.Pistas.FindAsync(id);
            if (pista == null)
            {
                return NotFound();
            }

            _context.Pistas.Remove(pista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PistaExists(int id)
        {
            return _context.Pistas.Any(e => e.Id == id);
        }
    }
}
