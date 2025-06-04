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
    public class PncController : ControllerBase
    {
        private readonly IPncApplication _application;
        private readonly IAppLogger<PncApplication> _logger;

        public PncController(IPncApplication application, IAppLogger<PncApplication> logger)
        {
            _application = application;
            _logger = logger;
        }

        [HttpPost("CrearActualizarPncsAsync")]
        public async Task<IActionResult> CrearActualizarPncsAsync([FromBody] List<PncDTO> modelList)
        {
            if (modelList == null || !modelList.Any())
                return BadRequest("La lista de PNCs está vacía.");

            var response = await _application.CrearActualizarPncsAsync(modelList);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }

}
