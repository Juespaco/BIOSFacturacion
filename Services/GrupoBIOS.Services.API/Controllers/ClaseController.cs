using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.Interface;
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
    public class ClaseController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IClaseApplication _Application;
        private static readonly HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAppLogger<ClaseApplication> _logger;

        public ClaseController(
            IClaseApplication _Application,
            IOptions<AppSettings> appSettings,
            IConfiguration config,              
            IWebHostEnvironment hostingEnvironment, 
            IAppLogger<ClaseApplication> logger)
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
            Response<IEnumerable<ClaseDTO>> response = new Response<IEnumerable<ClaseDTO>>();

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

        [HttpPost("CrearClase")]
        public async Task<IActionResult> CrearCLase(ClaseDTO model)
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

        [HttpPost("DesactivarClase")]
        public async Task<IActionResult> DesactivarClase(int IDClase)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (IDClase == 0)
                    return BadRequest();

                response = await this._Application.DesactivarClase(IDClase);

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

        [HttpPost("ActualizarClase")]
        public async Task<IActionResult> ActualizarCLase(ClaseDTO model)
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
        [HttpGet("GetClaseID")]
        public async Task<IActionResult> GetAsync(int IDClase)
        {
            Response<ClaseDTO> response = new Response<ClaseDTO>();

            try
            {
                if (IDClase == 0)
                    return BadRequest();

                response = await this._Application.GetAsync(IDClase);

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
    }
}
