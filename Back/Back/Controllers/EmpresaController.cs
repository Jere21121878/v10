using AutoMapper;
using Back.Models.DTO;
using Back.Models.Repository;
using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmpresaController(UserManager<ApplicationUser> userManager,IMapper mapper, IEmpresaRepository empresaRepository, AplicationDbContext context)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEmpre = await _empresaRepository.GetListEmpresas();
                var listEmpreDTO = _mapper.Map<IEnumerable<EmpresaDTO>>(listEmpre);
                return Ok(listEmpreDTO);
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
                var empresa = await _empresaRepository.GetEmpresa(Id);
                if (empresa == null)
                {
                    return NotFound();
                }

                var empresaDto = _mapper.Map<EmpresaDTO>(empresa);


                return Ok(empresaDto);
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
                var empresa = await _empresaRepository.GetEmpresa(Id);
                if (empresa == null)
                {
                    return NotFound();
                }

                await _empresaRepository.DeleteEmpresa(empresa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Empresa>> CreateEmpresa([FromForm] Empresa empresa, List<IFormFile> files)
        {
            try
            {
                _context.Empresas.Add(empresa);
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
                            EmpresaId = empresa.Id.ToString()
                        };
                        _context.Fotos.Add(foto);
                    }
                }
                await _context.SaveChangesAsync(); // Guardar las fotos
                return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, EmpresaDTO empresaDTO)
        {
            try
            {
                var empresa = _mapper.Map<Empresa>(empresaDTO);
                if (Id != empresa.Id)
                {
                    return BadRequest();
                }

                var empresaItem = await _empresaRepository.GetEmpresa(Id);
                if (empresaItem == null)
                {
                    return NotFound();
                }

                await _empresaRepository.UpdateEmpresa(empresa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("empleador/{empleadorId}")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresassByEmpleadorId(int empleadorId)
        {
            if (empleadorId <= 0)
            {
                return BadRequest("El parámetro 'empleadorId' es inválido.");
            }

            var empresas = await _context.Empresas.Where(a => a.EmpleadorId == empleadorId).ToListAsync();

            if (empresas == null || empresas.Count == 0)
            {
                return NotFound();
            }

            return empresas;
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpleadosByEmpleadorId(int empleadorId)
        {
            if (empleadorId <= 0)
            {
                return BadRequest("El parámetro 'empleadorId' es inválido.");
            }

            var empresas = await _context.Empresas.Where(a => a.EmpleadorId == empleadorId).ToListAsync();

            if (empresas == null || empresas.Count == 0)
            {
                return NotFound();
            }

            return empresas;
        }
        [HttpGet("usuarios/{empresaId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetUsuariosByEmpresaId(int empresaId)
        {
            try
            {
                if (empresaId <= 0)
                {
                    return BadRequest("El parámetro 'empresaId' es inválido.");
                }

                var usuarios = await _context.Users.Where(u => u.EmpresaId == empresaId).ToListAsync();

                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound();
                }

                var usuariosConRol = new List<object>();

                foreach (var usuario in usuarios)
                {
                    var rol = await _userManager.GetRolesAsync(usuario);
                    usuariosConRol.Add(new
                    {
                        Id = usuario.Id,
                        UserName = usuario.UserName,
                        Name = usuario.Name,
                        Apellido = usuario.Apellido,
                        Tsuperior = usuario.Tsuperior,
                        Acargo = usuario.Acargo,
                        Tinferior = usuario.Tinferior,
                        EmpleadorId = usuario.EmpleadorId,
                        EmpresaId = usuario.EmpresaId,
                        Rol = rol.FirstOrDefault() // Obtener el primer rol del usuario
                    });
                }

                return usuariosConRol;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}



