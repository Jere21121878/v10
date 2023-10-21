using AutoMapper;
using Back.Models.DTO;
using Back.Models.Repository;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public AtsController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ats>>> GetAtss()
        {
            return await _context.Atss.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ats>> GetAts(string id)
        {
            int atsId = int.Parse(id);
            var ats = await _context.Atss.FindAsync(atsId);

            if (ats == null)
            {
                return NotFound();
            }

            return ats;
        }

        [HttpPost]
        public async Task<ActionResult<Ats>> CreateAts(Ats ats)
        {
            _context.Atss.Add(ats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAts", new { id = ats.Id }, ats);
        }

        [HttpGet("tecnico/{tecnicoId}")]
        public async Task<ActionResult<IEnumerable<Ats>>> GetAtssByTecnicoId(string tecnicoId)
        {
            var atss = await _context.Atss.Where(a => a.tecnicoId == tecnicoId).ToListAsync();

            if (atss == null || atss.Count == 0)
            {
                return NotFound();
            }

            return atss;
        }

    }
}
