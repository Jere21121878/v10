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
    public class HerramientaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHerramientaRepository _herramientaRepository;

        public HerramientaController(IMapper mapper, IHerramientaRepository herramientaRepository)
        {
            _mapper = mapper;
            _herramientaRepository = herramientaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listHerramientas = await _herramientaRepository.GetListHerramientas();

                var listHerramientasDTO = _mapper.Map<IEnumerable<HerramientaDTO>>(listHerramientas);

                return Ok(listHerramientasDTO);
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
                var herramienta = await _herramientaRepository.GetHerramienta(Id);

                if (herramienta == null)
                {
                    return NotFound();
                }

                var herramientaDto = _mapper.Map<HerramientaDTO>(herramienta);

                return Ok(herramientaDto);

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
                var herramienta = await _herramientaRepository.GetHerramienta(Id);

                if (herramienta == null)
                {
                    return NotFound();
                }

                await _herramientaRepository.DeleteHerramienta(herramienta);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(HerramientaDTO herramientaDto)
        {
            try
            {
                var herramienta = _mapper.Map<Herramienta>(herramientaDto);



                herramienta = await _herramientaRepository.AddHerramienta(herramienta);

                var herramientaItemDto = _mapper.Map<HerramientaDTO>(herramienta);

                return CreatedAtAction("Get", new { Id = herramientaItemDto.Id }, herramientaItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, HerramientaDTO herramientaDto)
        {
            try
            {
                var herramienta = _mapper.Map<Herramienta>(herramientaDto);

                if (Id != herramienta.Id)
                {
                    return BadRequest();
                }

                var herramientaItem = await _herramientaRepository.GetHerramienta(Id);

                if (herramientaItem == null)
                {
                    return NotFound();
                }

                await _herramientaRepository.UpdateHerramienta(herramienta);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
