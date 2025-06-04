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
    public class CompaniaController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICompaniaApplication _Application;
        private readonly ITokenService _tokenService;

        private static readonly HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAppLogger<CompaniaApplication> _logger;


        public CompaniaController(
            ICompaniaApplication _Application,
            IOptions<AppSettings> appSettings,
            IConfiguration config,
            IWebHostEnvironment hostingEnvironment,
            IAppLogger<CompaniaApplication> logger,
            ITokenService tokenService)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<CompaniaDTO>> response = new Response<IEnumerable<CompaniaDTO>>();
            
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
            Response<CompaniaDTO> response = new Response<CompaniaDTO>();

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

        //[HttpPost("CrearCompaniaAsync")]
        //public async Task<IActionResult> CrearCompaniaAsync(CompaniaDTO model)
        //{
        //    Response<string> response = new Response<string>();

        //    try
        //    {
        //        if (model == null)
        //            return BadRequest();

        //        response = await this._Application.InsertAsync(model);

        //        if (response.IsSuccess)
        //        {

        //            return Ok(response);
        //        }
        //        else
        //        {
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Data = string.Empty;
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;

        //        _logger.LogError(ex.Message);

        //        return BadRequest(response);
        //    }
        //}

        //[HttpPost("ActualizarCompaniaAsync")]
        //public async Task<IActionResult> ActualizarCompaniaAsync(CompaniaDTO model)
        //{
        //    Response<string> response = new Response<string>();

        //    try
        //    {
        //        if (model == null)
        //            return BadRequest();

        //        response = await this._Application.UpdateAsync(model);

        //        if (response.IsSuccess)
        //        {

        //            return Ok(response);
        //        }
        //        else
        //        {
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Data = string.Empty;
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;

        //        _logger.LogError(ex.Message);

        //        return BadRequest(response);
        //    }
        //}

        //[HttpDelete("DesactivarCompaniaAsync")]
        //public async Task<IActionResult> DesactivarCompaniaAsync(int IDCompania)
        //{
        //    Response<bool> response = new Response<bool>();

        //    try
        //    {
        //        response = await _Application.DesactivarCompania(IDCompania);
        //        if (response.IsSuccess)
        //        {
        //            return Ok(response);
        //        }
        //        else
        //        {
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Data = false;
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;

        //        _logger.LogError(ex.Message);

        //        return BadRequest(response);
        //    }
        //}

        [HttpGet("ObtenerConfiguracionCompaniaPorIDSiesa")]
        public async Task<IActionResult> ObtenerConfiguracionCompaniaPorIDSiesa(int IDSiesa)
        {
            Response<ConfiguracionCompaniaDTO> response = new Response<ConfiguracionCompaniaDTO>();

            try
            {
                response = await _Application.ObtenerConfiguracionPorIDSiesaAsync(IDSiesa);
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

        [HttpPost("CrearActualizarConfiguracionCompaniaAsync")]
        public async Task<IActionResult> CrearActualizarConfiguracionCompaniaAsync(ConfiguracionCompaniaDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null || string.IsNullOrEmpty(model.Compania.IDSiesa.ToString()) || model.Compania.IDSiesa == 0)
                    return BadRequest();

                response = await this._Application.ConfigurationAsync(model);

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
