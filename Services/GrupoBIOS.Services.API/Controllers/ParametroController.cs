using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Application.Main;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Transversal.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GrupoBIOS.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ParametroController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IParametroApplication _Application;
        private static readonly HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAppLogger<ParametroApplication> _logger;

        public ParametroController(
            IParametroApplication _Application,
            IOptions<AppSettings> appSettings,
            IConfiguration config,
            IWebHostEnvironment hostingEnvironment,
            IAppLogger<ParametroApplication> logger)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<ParametroDTO>> response = new Response<IEnumerable<ParametroDTO>>();

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

        [HttpPost("CrearParametro")]
        public async Task<IActionResult> CrearParametro(ParametroDTO model)
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

        [HttpGet("GetParametroClase")]
        public async Task<IActionResult> GetParametroClase(int IDClase)
        {
            Response<IEnumerable<ParametroDTO>> response = new Response<IEnumerable<ParametroDTO>>();

            try
            {
                if (IDClase == 0)
                    return BadRequest();

                response = await this._Application.GetParametroClase(IDClase);

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

        [HttpGet("GetParametroID")]
        public async Task<IActionResult> GetAsync(int IDParametro)
        {
            Response<ParametroDTO> response = new Response<ParametroDTO>();

            try
            {
                if (IDParametro == 0)
                    return BadRequest();

                response = await this._Application.GetAsync(IDParametro);

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

        [HttpPost("DesactivarParametro")]
        public async Task<IActionResult> DesactivarParametro(int ID)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (ID == 0)
                    return BadRequest();

                response = await this._Application.DesactivarParametro(ID);

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

        [HttpPost("ActualizarParametro")]
        public async Task<IActionResult> ActualizarParametro(ParametroDTO model)
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
    }
}
