using AutoMapper;
using Back.Models;
using Back.Models.DTO;
using Back.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuimicoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IQuimicoRepository _quimicoRepository;

        public QuimicoController(IMapper mapper, IQuimicoRepository quimicoRepository)
        {
            _mapper = mapper;
            _quimicoRepository = quimicoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listQuimicos = await _quimicoRepository.GetListQuimicos();

                var listQuimicosDTO = _mapper.Map<IEnumerable<QuimicoDTO>>(listQuimicos);

                return Ok(listQuimicosDTO);
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
                var quimico = await _quimicoRepository.GetQuimico(Id);

                if (quimico == null)
                {
                    return NotFound();
                }

                var quimicoDto = _mapper.Map<QuimicoDTO>(quimico);

                return Ok(quimicoDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int  Id)
        {
            try
            {
                var quimico = await _quimicoRepository.GetQuimico(Id);

                if (quimico == null)
                {
                    return NotFound();
                }

                await _quimicoRepository.DeleteQuimico(quimico);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuimicoDTO quimicoDto)
        {
            try
            {
                var quimico = _mapper.Map<Quimico>(quimicoDto);

                

                quimico = await _quimicoRepository.AddQuimico(quimico);

                var quimicoItemDto = _mapper.Map<QuimicoDTO>(quimico);

                return CreatedAtAction("Get", new { Id = quimicoItemDto.Id }, quimicoItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, QuimicoDTO quimicoDto)
        {
            try
            {
                var quimico = _mapper.Map<Quimico>(quimicoDto);

                if (Id != quimico.Id)
                {
                    return BadRequest();
                }

                var mascotaItem = await _quimicoRepository.GetQuimico(Id);

                if (mascotaItem == null)
                {
                    return NotFound();
                }

                await _quimicoRepository.UpdateQuimico(quimico);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
