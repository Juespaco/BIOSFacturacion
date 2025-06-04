using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Application.DTOs.Response.Auth;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Application.Interface.Service;
using GrupoBIOS.Application.Main;
using GrupoBIOS.Transversal.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GrupoBIOS.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class NivelController : ControllerBase
    {
        private readonly INivelApplication _application;
        private readonly IAppLogger<NivelController> _logger;

        public NivelController(INivelApplication application, IAppLogger<NivelController> logger)
        {
            _application = application;
            _logger = logger;
        }

        [HttpPost("CrearActualizarNivelesAsync")]
        public async Task<IActionResult> CrearActualizarNivelesAsync([FromBody] List<NivelDTO> modelList)
        {
            if (modelList == null || !modelList.Any())
                return BadRequest("La lista de Niveles está vacía.");

            var response = await _application.CrearActualizarNivelesAsync(modelList);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }

}
