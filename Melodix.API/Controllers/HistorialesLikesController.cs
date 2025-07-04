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
    public class HistorialesLikesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistorialesLikesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialesLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialLike>>> GetHistorialLike()
        {
            return await _context.HistorialesLikes.ToListAsync();
        }

        // GET: api/HistorialesLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialLike>> GetHistorialLike(int id)
        {
            var historialLike = await _context.HistorialesLikes.FindAsync(id);

            if (historialLike == null)
            {
                return NotFound();
            }

            return historialLike;
        }

        // PUT: api/HistorialesLikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialLike(int id, HistorialLike historialLike)
        {
            if (id != historialLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(historialLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialLikeExists(id))
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

        // POST: api/HistorialesLikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialLike>> PostHistorialLike(HistorialLike historialLike)
        {
            _context.HistorialesLikes.Add(historialLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialLike", new { id = historialLike.Id }, historialLike);
        }

        // DELETE: api/HistorialesLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialLike(int id)
        {
            var historialLike = await _context.HistorialesLikes.FindAsync(id);
            if (historialLike == null)
            {
                return NotFound();
            }

            _context.HistorialesLikes.Remove(historialLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialLikeExists(int id)
        {
            return _context.HistorialesLikes.Any(e => e.Id == id);
        }
    }
}
