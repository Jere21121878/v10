using AutoMapper;
using Back.Models.DTO;
using Back.Models.Repository;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadorController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmpleadorRepository _empleadorRepository;

        public EmpleadorController(IMapper mapper, IEmpleadorRepository empleadorRepository, AplicationDbContext context)
        {
            _mapper = mapper;
            _empleadorRepository = empleadorRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEmple = await _empleadorRepository.GetListEmpleadors();
                var listEmpleDTO = _mapper.Map<IEnumerable<EmpleadorDTO>>(listEmple);
                return Ok(listEmpleDTO);
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
                var empleador = await _empleadorRepository.GetEmpleador(Id);
                if (empleador == null)
                {
                    return NotFound();
                }

                var empleadorDto = _mapper.Map<EmpleadorDTO>(empleador);

               
                return Ok(empleadorDto);
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
                var empleador = await _empleadorRepository.GetEmpleador(Id);
                if (empleador == null)
                {
                    return NotFound();
                }

                await _empleadorRepository.DeleteEmpleador(empleador);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Empleador>> CreateEmpleador([FromForm] Empleador empleador)
        {
            try
            {
                _context.Empleadors.Add(empleador);
                await _context.SaveChangesAsync(); // Guardar el local primero

                
                return CreatedAtAction(nameof(Get), new { id = empleador.Id }, empleador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, EmpleadorDTO empleadorDTO)
        {
            try
            {
                var empleador = _mapper.Map<Empleador>(empleadorDTO);
                if (Id != empleador.Id)
                {
                    return BadRequest();
                }

                var empleadorItem = await _empleadorRepository.GetEmpleador(Id);
                if (empleadorItem == null)
                {
                    return NotFound();
                }

                await _empleadorRepository.UpdateEmpleador(empleador);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       


    }
}
