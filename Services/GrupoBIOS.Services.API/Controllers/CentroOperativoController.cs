using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Application.Interface.Service;
using GrupoBIOS.Application.Main;
using GrupoBIOS.Application.Main.Service;
using GrupoBIOS.Transversal.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GrupoBIOS.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CentroOperativoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICentroOperativoApplication _Application;
        private static readonly HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        private readonly IAppLogger<CentroOperativoApplication> _logger;

        public CentroOperativoController(
            ICentroOperativoApplication _Application,
            IOptions<AppSettings> appSettings,
            IConfiguration config,
            IWebHostEnvironment hostingEnvironment,
            IAppLogger<CentroOperativoApplication> logger,
            ITokenService tokenService)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
            _config = config;            
            _logger = logger;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<CentroOperativoDTO>> response = new Response<IEnumerable<CentroOperativoDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(int IDCompania)
        {
            Response<CentroOperativoDTO> response = new Response<CentroOperativoDTO>();

            try
            {
                response = await _Application.GetAsync(IDCompania);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("CrearCentroOperativoAsync")]
        public async Task<IActionResult> CrearCentroOperativoAsync(CentroOperativoDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();

                response = await this._Application.InsertAsync(model);

                if (response.IsSuccess)
                {

                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("ActualizarCentroOperativoAsync")]
        public async Task<IActionResult> ActualizarCentroOperativoAsync(CentroOperativoDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();

                response = await this._Application.UpdateAsync(model);

                if (response.IsSuccess)
                {

                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpDelete("DesactivarCentroOperativoAsync")]
        public async Task<IActionResult> DesactivarCentroOperativoAsync(int IDCompania)
        {
            Response<bool> response = new Response<bool>();

            try 
            {
                response = await _Application.DesactivarCentroOperativo(IDCompania);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("CrearActualizarCentroOperativoAsync")]
        public async Task<IActionResult> CrearActualizarCentroOperativoAsync([FromBody] List<CentroOperativoDTO> centros)
        {
            var response = new Response<string>();

            try
            {
                if (centros == null || !centros.Any())
                    return BadRequest("La lista de Centros Operativos está vacía.");

                response = await _Application.CrearActualizarCentroOperativoAsync(centros);

                return response.IsSuccess ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

    }
}
