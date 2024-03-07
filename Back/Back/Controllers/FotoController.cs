using AutoMapper;
using Back.Models;
using Back.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        private readonly AplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly IFotoRepository _fotoRepository;

        public FotoController(IMapper mapper, IFotoRepository fotoRepository, AplicationDbContext context)
        {
            _mapper = mapper;
            _fotoRepository = fotoRepository;
            _context = context;

        }
        [HttpGet("empresa/{empresaId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByEmpresalId(string empresaId)
        {
            if (string.IsNullOrEmpty(empresaId))
            {
                return BadRequest("El parámetro 'EmpresaId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.EmpresaId == empresaId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }
        [HttpGet("quimico/{quimicoId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByQuimicolId(string quimicoId)
        {
            if (string.IsNullOrEmpty(quimicoId))
            {
                return BadRequest("El parámetro 'QuimicoId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.QuimicoId == quimicoId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }
        [HttpGet("herramienta/{herramientaId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByHerramientalId(string herramientaId)
        {
            if (string.IsNullOrEmpty(herramientaId))
            {
                return BadRequest("El parámetro 'HerramientaId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.HerramientaId == herramientaId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }
        [HttpGet("plano/{planoId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByPlanoId(string planoId)
        {
            if (string.IsNullOrEmpty(planoId))
            {
                return BadRequest("El parámetro 'PlanoId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.PlanoId == planoId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }
        [HttpGet("tecnico/{tecnicoId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByTecnicoId(string tecnicoId)
        {
            if (string.IsNullOrEmpty(tecnicoId))
            {
                return BadRequest("El parámetro 'TecnicoId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.TecnicoId == tecnicoId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }
        [HttpGet("licenciado/{licenciadoId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByLicenciadoId(string licenciadoId)
        {
            if (string.IsNullOrEmpty(licenciadoId))
            {
                return BadRequest("El parámetro 'LicenciadoId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.LicenciadoId == licenciadoId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }
    }
}
