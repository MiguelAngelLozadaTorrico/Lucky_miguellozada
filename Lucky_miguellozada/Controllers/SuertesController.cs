using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lucky_miguellozada.Data;
using Lucky_miguellozada.Models;

namespace Lucky_miguellozada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuertesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuertesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Suertes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suerte>>> GetSuertesita()
        {
            return await _context.Suertesita.ToListAsync();
        }

        // GET: api/Suertes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suerte>> GetSuerte(int id)
        {
            var suerte = await _context.Suertesita.FindAsync(id);

            if (suerte == null)
            {
                return NotFound();
            }

            return suerte;
        }

        // PUT: api/Suertes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuerte(int id, Suerte suerte)
        {
            if (id != suerte.SuerteId)
            {
                return BadRequest();
            }

            _context.Entry(suerte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuerteExists(id))
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

        // POST: api/Suertes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suerte>> PostSuerte(Suerte suerte)
        {
            _context.Suertesita.Add(suerte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuerte", new { id = suerte.SuerteId }, suerte);
        }

        // DELETE: api/Suertes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuerte(int id)
        {
            var suerte = await _context.Suertesita.FindAsync(id);
            if (suerte == null)
            {
                return NotFound();
            }

            _context.Suertesita.Remove(suerte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuerteExists(int id)
        {
            return _context.Suertesita.Any(e => e.SuerteId == id);
        }
    }
}
