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
    public class PlanoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPlanoRepository _planoRepository;
        private readonly AplicationDbContext _context;

        public PlanoController(IMapper mapper, IPlanoRepository planoRepository, AplicationDbContext context)
        {
            _mapper = mapper;
            _planoRepository = planoRepository;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPlano = await _planoRepository.GetListPlanos();

                var listPlanoDTO = _mapper.Map<IEnumerable<PlanoDTO>>(listPlano);

                return Ok(listPlanoDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var plano = await _planoRepository.GetPlano(Id);

                if (plano == null)
                {
                    return NotFound();
                }

                var planoDto = _mapper.Map<PlanoDTO>(plano);

                return Ok(planoDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var plano = await _planoRepository.GetPlano(Id);

                if (plano == null)
                {
                    return NotFound();
                }

                await _planoRepository.DeletePlano(plano);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Plano>> CreateEmpresa([FromForm] Plano plano, List<IFormFile> files)
        {
            try
            {
                _context.Planos.Add(plano);
                await _context.SaveChangesAsync(); // Guardar el local primero

                foreach (var file in files)
                {
                    using (var stream = new System.IO.MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        var foto = new Foto
                        {
                            NombreFo = file.FileName,
                            Data = stream.ToArray(),
                            PlanoId = plano.Id.ToString()
                        };
                        _context.Fotos.Add(foto);
                    }
                }
                await _context.SaveChangesAsync(); // Guardar las fotos
                return CreatedAtAction(nameof(Get), new { id = plano.Id }, plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, PlanoDTO planoDto)
        {
            try
            {
                var plano = _mapper.Map<Plano>(planoDto);

                if (Id != plano.Id)
                {
                    return BadRequest();
                }

                var planoItem = await _planoRepository.GetPlano(Id);

                if (planoItem == null)
                {
                    return NotFound();
                }

                await _planoRepository.UpdatePlano(plano);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("empresa/{empresaId}")]
        public async Task<ActionResult<IEnumerable<Plano>>> GetPlanossByEmpresaId(int empresaId)
        {
            if (empresaId <= 0)
            {
                return BadRequest("El parámetro 'EmpresaId' es inválido.");
            }

            var planos = await _context.Planos.Where(a => a.EmpresaId == empresaId).ToListAsync();

            if (planos == null || planos.Count == 0)
            {
                return NotFound();
            }

            return planos;
        }

    }
}
