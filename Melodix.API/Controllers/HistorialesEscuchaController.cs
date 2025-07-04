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
    public class HistorialesEscuchaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialesEscuchaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialesEscucha
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialEscucha>>> GetHistorialEscucha()
        {
            return await _context.HistorialesEscucha.ToListAsync();
        }

        // GET: api/HistorialesEscucha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialEscucha>> GetHistorialEscucha(int id)
        {
            var historialEscucha = await _context.HistorialesEscucha.FindAsync(id);

            if (historialEscucha == null)
            {
                return NotFound();
            }

            return historialEscucha;
        }

        // PUT: api/HistorialesEscucha/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialEscucha(int id, HistorialEscucha historialEscucha)
        {
            if (id != historialEscucha.Id)
            {
                return BadRequest();
            }

            _context.Entry(historialEscucha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialEscuchaExists(id))
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

        // POST: api/HistorialesEscucha
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialEscucha>> PostHistorialEscucha(HistorialEscucha historialEscucha)
        {
            _context.HistorialesEscucha.Add(historialEscucha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialEscucha", new { id = historialEscucha.Id }, historialEscucha);
        }

        // DELETE: api/HistorialesEscucha/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialEscucha(int id)
        {
            var historialEscucha = await _context.HistorialesEscucha.FindAsync(id);
            if (historialEscucha == null)
            {
                return NotFound();
            }

            _context.HistorialesEscucha.Remove(historialEscucha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialEscuchaExists(int id)
        {
            return _context.HistorialesEscucha.Any(e => e.Id == id);
        }
    }
}
