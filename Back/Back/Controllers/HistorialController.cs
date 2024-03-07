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
    public class HistorialController : ControllerBase
    {


        private readonly IMapper _mapper;
        private readonly IHistorialRepository _historialRepository;
        private readonly AplicationDbContext _context;

        public HistorialController(IMapper mapper, IHistorialRepository historialRepository, AplicationDbContext context)
        {
            _mapper = mapper;
            _historialRepository = historialRepository;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listHistorials = await _historialRepository.GetListHistorials();

                var listHistorialDTO = _mapper.Map<IEnumerable<HistorialDTO>>(listHistorials);

                return Ok(listHistorialDTO);
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
                var historial = await _historialRepository.GetHistorial(Id);

                if (historial == null)
                {
                    return NotFound();
                }

                var historialDto = _mapper.Map<HistorialDTO>(historial);

                return Ok(historialDto);

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
                var historial = await _historialRepository.GetHistorial(Id);

                if (historial == null)
                {
                    return NotFound();
                }

                await _historialRepository.DeleteHistorial(historial);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(HistorialDTO historialDto)
        {
            try
            {
                var historial = _mapper.Map<Historial>(historialDto);

                historial.Fecha = DateTime.Now;

                historial = await _historialRepository.AddHistorial(historial);

                var historialItemDto = _mapper.Map<HistorialDTO>(historial);

                return CreatedAtAction("Get", new { Id = historialItemDto.Id }, historialItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, HistorialDTO historialDto)
        {
            try
            {
                var historial = _mapper.Map<Historial>(historialDto);

                if (Id != historial.Id)
                {
                    return BadRequest();
                }

                var historialItem = await _historialRepository.GetHistorial(Id);

                if (historialItem == null)
                {
                    return NotFound();
                }

                await _historialRepository.UpdateHistorial(historial);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("empresa/{empresaId}")]
        public async Task<ActionResult<IEnumerable<Historial>>> GetHistorialsByEmpresaId(int empresaId)
        {
            if (empresaId <= 0)
            {
                return BadRequest("El parámetro 'empleadorId' es inválido.");
            }

            var historials = await _context.Historials.Where(a => a.EmpresaId == empresaId).ToListAsync();

            if (historials == null || historials.Count == 0)
            {
                return NotFound();
            }

            return historials;
        }


    }
}
