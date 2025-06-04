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
    public class ExcepcionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IExcepcionApplication _Application;
        private readonly ITokenService _tokenService;

        private static readonly HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAppLogger<ExcepcionApplication> _logger;


        public ExcepcionController(
            IExcepcionApplication _Application,
            IOptions<AppSettings> appSettings,
            IConfiguration config,
            IWebHostEnvironment hostingEnvironment,
            IAppLogger<ExcepcionApplication> logger,
            ITokenService tokenService)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpPost("CrearActualizarExcepcionesAsync")]
        public async Task<IActionResult> CrearActualizarExcepcionesAsync([FromBody] List<ExcepcionDTO> modelList)
        {
            var response = new Response<string>();

            try
            {
                if (modelList == null || !modelList.Any())
                    return BadRequest("La lista de excepciones está vacía.");

                response = await _Application.CrearActualizarExcepcionesAsync(modelList);

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
