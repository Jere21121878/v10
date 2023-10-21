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
    public class LegalController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILegalRepository _legalRepository;

        public LegalController(IMapper mapper, ILegalRepository legalRepository)
        {
            _mapper = mapper;
            _legalRepository = legalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listlegal = await _legalRepository.GetListLegals();

                var listlegalDTO = _mapper.Map<IEnumerable<LegalDTO>>(listlegal);

                return Ok(listlegalDTO);
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
                var legal = await _legalRepository.GetLegal(Id);

                if (legal == null)
                {
                    return NotFound();
                }

                var legalDto = _mapper.Map<LegalDTO>(legal);

                return Ok(legalDto);

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
                var legal = await _legalRepository.GetLegal(Id);

                if (legal == null)
                {
                    return NotFound();
                }

                await _legalRepository.DeleteLegal(legal);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(LegalDTO legalDto)
        {
            try
            {
                var legal = _mapper.Map<Legal>(legalDto);

               

                legal = await _legalRepository.AddLegal(legal);

                var legalItemDto = _mapper.Map<LegalDTO>(legal);

                return CreatedAtAction("Get", new { Id = legalItemDto.Id }, legalItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, LegalDTO legalDto)
        {
            try
            {
                var legal = _mapper.Map<Legal>(legalDto);

                if (Id != legal.Id)
                {
                    return BadRequest();
                }

                var legalItem = await _legalRepository.GetLegal(Id);

                if (legalItem == null)
                {
                    return NotFound();
                }

                await _legalRepository.UpdateLegal(legal);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
