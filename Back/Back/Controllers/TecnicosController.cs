using Back.Models;
using Back.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<TecnicosController> _logger;

        public TecnicosController(UserManager<ApplicationUser> userManager, ILogger<TecnicosController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet("asignados/{licenciadoId}")]
        public async Task<IActionResult> GetTecnicosAsignados(string licenciadoId)
        {
            try
            {
                var licenciado = await _userManager.FindByIdAsync(licenciadoId);
                var tecnicosAsignados = await _userManager.GetUsersInRoleAsync(UserRoles.Tecnico);

                var tecnicos = tecnicosAsignados.Where(t => t.Acargo == licenciado.Id).Select(t => new

                {
                    t.Id,
                    t.Name,
                    t.Apellido,
                    t.Tsuperior,
                    t.Tinferior
                });

                return Ok(tecnicos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting Tecnicos assigned to Licenciado");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting Tecnicos assigned to Licenciado");
            }
        }
        //[HttpGet("asignados/{licenciadoId}")]
        //public async Task<IActionResult> GetTecnicosAsignados(string licenciadoId)
        //{
        //    try
        //    {
        //        var tecnicos = await _userManager.GetUsersInRoleAsync(UserRoles.Tecnico);
        //        var tecnicosAsignados = tecnicos.Where(t => t.Acargo == licenciadoId).Select(t => new
        //        {
        //            t.Id,
        //            t.Name,
        //            t.Apellido,
        //            t.Tsuperior,
        //            t.Tinferior
        //        });

        //        return Ok(tecnicosAsignados);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while getting Tecnicos assigned to Licenciado");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting Tecnicos assigned to Licenciado");
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> GetTecnicosWithLicenciados()
        {
            try
            {
                var tecnicos = await _userManager.GetUsersInRoleAsync(UserRoles.Tecnico);
                var tecnicosList = tecnicos.Select(async t => new
                {
                    t.Id,
                    t.Name,
                    t.Apellido,
                    t.Tsuperior,
                    t.Tinferior,
                    LicenciadoACargo = new
                    {
                        Id = t.Acargo,
                        Nombre = t.Acargo != null ? await GetLicenciadoNameById(t.Acargo) : null
                    }
                });

                return Ok(tecnicosList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting Tecnicos with Licenciados");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting Tecnicos with Licenciados");
            }
        }

        private async Task<string?> GetLicenciadoNameById(string licenciadoId)
        {
            var licenciado = await _userManager.FindByIdAsync(licenciadoId);
            if (licenciado != null)
            {
                return $"{licenciado.Name} {licenciado.Apellido}";
            }
            return null;
        }
        [HttpPost]
        [Route("asignarlicenciado/{licenciadoId}/{tecnicoId}")]
        public async Task<IActionResult> AsignarLicenciado(string licenciadoId, string tecnicoId)
        {
            try
            {
                var licenciado = await _userManager.FindByIdAsync(licenciadoId);
                if (licenciado == null)
                {
                    return NotFound("Licenciado not found");
                }

                var tecnico = await _userManager.FindByIdAsync(tecnicoId);
                if (tecnico == null)
                {
                    return NotFound("Tecnico not found");
                }

                if (!string.IsNullOrEmpty(tecnico.Acargo))
                {
                    return Conflict("Tecnico already has a Licenciado assigned");
                }

                tecnico.Acargo = licenciadoId;
                var updateResult = await _userManager.UpdateAsync(tecnico);
                if (!updateResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while assigning Licenciado to Tecnico");
                }

                return Ok("Licenciado assigned successfully to Tecnico");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while assigning Licenciado to Tecnico");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while assigning Licenciado to Tecnico");
            }
        }

        


}
}
