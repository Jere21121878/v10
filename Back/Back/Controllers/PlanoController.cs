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
    public class PlanoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlanoRepository _planoRepository;

        public PlanoController(IMapper mapper, IPlanoRepository planoRepository)
        {
            _mapper = mapper;
            _planoRepository = planoRepository;
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
        public async Task<IActionResult> Post(PlanoDTO planoDto)
        {
            try
            {
                var plano = _mapper.Map<Plano>(planoDto);



                plano = await _planoRepository.AddPlano(plano);

                var planoItemDto = _mapper.Map<PlanoDTO>(plano);

                return CreatedAtAction("Get", new { Id = planoItemDto.Id }, planoItemDto);

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
    }
}
